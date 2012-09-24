﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Element;
using EvilDICOM.Core.Extensions;
using EvilDICOM.Core.Helpers;
using System.Reflection;

namespace EvilDICOM.Core
{
    /// <summary>
    /// The DICOM object is a container for DICOM elements. It contains methods for finding elements easily from within the structure.
    /// </summary>
    public class DICOMObject
    {
        private List<IDICOMElement> _elements = new List<IDICOMElement>();

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="elements">a list of elements to be included in the object</param>
        public DICOMObject(List<IDICOMElement> elements)
        {
            _elements = elements;
        }

        /// <summary>
        /// Adds an element to the DICOM object
        /// </summary>
        /// <param name="el">a DICOM element to be added</param>
        public void Add(IDICOMElement el)
        {
            _elements.Add(el);
            _elements.SortByTagID();
        }

        /// <summary>
        /// The list of first level DICOM elements inside this DICOM object
        /// </summary>
        public List<IDICOMElement> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        /// <summary>
        /// The list of all DICOM elements at every level in the DICOM structure (includes sub-elements of sequences)
        /// </summary>
        public List<IDICOMElement> AllElements
        {
            get
            {
                List<IDICOMElement> allElements = new List<IDICOMElement>();
                foreach (IDICOMElement elem in Elements)
                {
                    allElements.Add(elem);
                    if (elem is Sequence)
                    {
                        Sequence s = elem as Sequence;
                        foreach (DICOMObject d in s.Items)
                        {
                            foreach (IDICOMElement elem2 in d.AllElements)
                            {
                                allElements.Add(elem2);
                            }
                        }
                    }
                }
                return allElements;
            }
        }

        /// <summary>
        /// Finds all DICOM elements that match a VR type
        /// </summary>
        /// <param name="vrToFind">the VR type to find</param>
        /// <returns>a list of all elements that meet the search criteria</returns>
        public List<IDICOMElement> FindAll(VR vrToFind)
        {
            return AllElements.Where(el => el.IsVR(vrToFind)).ToList();
        }

        /// <summary>
        /// Finds all DICOM elements that match an element type
        /// </summary>
        /// <typeparam name="T">the DICOM element class that is being filtered and returned</typeparam>
        /// <returns>a list of all elements that are strongly typed</returns>
        public List<T> FindAll<T>() 
        {
            Type t = typeof(T);
            return AllElements.Where(el => el is T).Select(el=>(T)Convert.ChangeType(el,t, CultureInfo.InvariantCulture)).ToList();
        }

        /// <summary>
        /// Finds all DICOM elements that match a certain tag
        /// </summary>
        /// <param name="tag">the tag to find</param>
        /// <returns>a list of all elements that meet the search criteria</returns>
        public List<IDICOMElement> FindAll(string tag)
        {
            return AllElements.Where(el => el.Tag.CompleteID == tag).ToList();
        }

        /// <summary>
        /// Finds all DICOM elements that match a certain tag
        /// </summary>
        /// <param name="tag">the tag to find</param>
        /// <returns>a list of all elements that meet the search criteria</returns>
        public List<IDICOMElement> FindAll(Tag tag)
        {
            return FindAll(tag.CompleteID);
        }

        /// <summary>
        /// Finds all DICOM elements that are embedded in the DICOM structure in some particular location. This location 
        /// is defined by descending tags from the outer most elements to the element. It is not necessary to include every 
        /// tag in the descending "treelike" structure. Branches can be skipped.
        /// </summary>
        /// <param name="descendingTags">a string array containing in order the tags from the outer most elements to the element being searched for</param>
        /// <returns>a list of all elements that meet the search criteria</returns>
        public List<IDICOMElement> FindAll(string[] descendingTags)
        {
            List<IDICOMElement> matches = new List<IDICOMElement>();
            if (descendingTags.Length > 1)
            {
                string[] newDescTags = ArrayHelper.Pop(descendingTags);
                List<IDICOMElement> sequences = AllElements.Where(e => e.IsVR(VR.Sequence)).Where(el => el.Tag.CompleteID == descendingTags[0]).ToList();
                foreach (IDICOMElement seq in sequences)
                {
                    Sequence s = seq as Sequence;
                    foreach (DICOMObject d in s.Items)
                    {
                        foreach (IDICOMElement el in d.FindAll(newDescTags))
                        {
                            matches.Add(el);
                        }
                    }
                }
            }
            else
            {
                matches = AllElements.Where(el => el.Tag.CompleteID == descendingTags[0]).ToList();
            }

            return matches;
        }

        /// <summary>
        /// Finds all DICOM elements that are embedded in the DICOM structure in some particular location. This location 
        /// is defined by descending tags from the outer most elements to the element. It is not necessary to include every 
        /// tag in the descending "treelike" structure. Branches can be skipped.
        /// </summary>
        /// <param name="descendingTags">a tag array containing in order the tags from the outer most elements to the element being searched for</param>
        /// <returns>a list of all elements that meet the search criteria</returns>
        public List<IDICOMElement> FindAll(Tag[] descendingTags)
        {
            return FindAll(descendingTags.Select(t => t.CompleteID).ToArray());
        }

        /// <summary>
        /// Finds the first element in the entire DICOM structure that has a certain tag
        /// </summary>
        /// <param name="toFind">the tag to be searched</param>
        /// <returns>one single DICOM element that is first occurence of the tag in the structure</returns>
        public IDICOMElement FindFirst(string toFind)
        {
            IDICOMElement found = AllElements.FirstOrDefault(el => el.Tag.CompleteID == toFind);
            return found;
        }

        /// <summary>
        /// Finds the first element in the entire DICOM structure that has a certain tag
        /// </summary>
        /// <param name="toFind">the tag to be searched</param>
        /// <returns>one single DICOM element that is first occurence of the tag in the structure</returns>
        public IDICOMElement FindFirst(Tag toFind)
        {
            return FindFirst(toFind.CompleteID);
        }

        public void Remove(string tag)
        {
            var removes = Elements.Where(el => el.Tag.CompleteID.Equals(tag));
            foreach (var remove in removes) Elements.Remove(remove);

            foreach (var elem in Elements)
            {
                if (elem is Sequence)
                {
                    Sequence s = elem as Sequence;
                    foreach (DICOMObject d in s.Items)
                    {
                        d.Remove(tag);
                    }
                }
            }
        }

        /// <summary>
        /// Replaces a current instance of the DICOM element in the DICOM object. If the object does not exist, this method
        /// exits. For this scenario, please use ReplaceOrAdd().
        /// </summary>
        /// <typeparam name="T">the type of the element being added (eg. UnsignedLong)</typeparam>
        /// <param name="element">the instance of the element</param>
        public void Replace<T>(T element)
        {
            IDICOMElement elementCast = element as IDICOMElement;
            T toReplace = (T)FindFirst(elementCast.Tag);
            if (toReplace != null)
            {
                object newData = element.GetType().GetProperty("Data").GetValue(element, null);
                toReplace.GetType().InvokeMember("Data", BindingFlags.SetProperty, null, toReplace, new object[] { newData });
            }
        }
        /// <summary>
        /// Replaces a current instance of the DICOM element in the DICOM object. If the object does not exist, this method 
        /// will add it to the object.
        /// </summary>
        /// <typeparam name="T">the type of the element being added (eg. UnsignedLong)</typeparam>
        /// <param name="element">the instance of the element</param>
        public void ReplaceOrAdd<T>(T element)
        {
            IDICOMElement elementCast = element as IDICOMElement;
            T toReplace = (T)FindFirst(elementCast.Tag);
            if (toReplace != null)
            {
                object newData = element.GetType().GetProperty("Data").GetValue(element, null);
                toReplace.GetType().InvokeMember("Data", BindingFlags.SetProperty, null, toReplace, new object[] { newData });
            }
            else
            {
                Add(elementCast);
            }
        }
    }
}
