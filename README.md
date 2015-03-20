Portable Evil DICOM
===================

Copyright (c) 2011-2014 Rex Cardan.
Portable Class Library adaptation (c) 2012-2014 Anders Gustafsson, Cureos AB.

A simple to use C# library for reading and manipulating DICOM files. 
Github is just the distro.

This project is a Portable Class Library adapted fork of Rex Cardan's original [Evil DICOM](https://github.com/rexcardan/Evil-DICOM) library. 
For general information, online API and Getting Started tutorials, see [here](http://rexcardan.com/evildicom).

The following links will help you get started:

Project website at 
http://rexcardan.com/evildicom

Content | Link
------------- | -------------
Introductory Video | https://www.youtube.com/watch?v=rmYpxxqQ90s
Examples | http://rexcardan.com/evildicom
Online API | http://www.rexcardan.com/api/evildicom/index.html
Applicability
-------------

The _EvilDicom.Core_ Visual Studio solution contains a _Portable Class Library_ project and a unit test project. The PCL library _EvilDICOM.Core_ supports the following targets:

* .NET Framework version 4.5 and higher
* Windows 8 and higher (f.k.a. Metro)
* Silverlight version 5 and higher
* Windows Phone (Silverlight) version 8 and higher
* Windows Phone 8.1 and higher
* Xamarin.Android
* Xamarin.iOS

Public API Differences
----------------------

To meet the requirements of a _Portable Class Library_ project, the PCL library public API differs from Rex Cardan's original _.NET 4_ library as follows:

* `DICOMBinaryReader` and `DICOMBinaryWriter` constructors, `DICOMFileReader.Read`, `DICOMFileReader.ReadFileMetadata`, `DICOMFileWriter.WriteLittleEndian`, `DICOMObject.Open` and `DICOMObject.SaveAs` methods takes a `Stream` argument instead of a file path `string`.

PCL example usage
-----------------

Read a DICOM file with the name `path`:

    var dcm = DICOMFileReader.Read(File.OpenRead(path));			// .NET and (Windows Phone) Silverlight applications

Write DICOM object `dcm` to a file with the name `path`:

    DICOMFileWriter.WriteLittleEndian(File.OpenWrite(path), dcm);	// .NET and (Windows Phone) Silverlight applications
