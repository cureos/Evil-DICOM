![Alt text](http://evildicom.rexcardan.com/images/evilDICOMlogo.png)

Portable Evil DICOM - A DICOM library in C#
===========================================

Copyright (c) 2011-2013 Rex Cardan, Portable Class Library adaptation (c) 2012-2013 Anders Gustafsson, Cureos AB

This project is a Portable Class Library adapted fork of Rex Cardan's original [Evil DICOM](https://github.com/rexcardan/Evil-DICOM) library. 
For general information and tutorials, see [here](http://evildicom.rexcardan.com/).

Applicability
-------------

The _EvilDicom.Core_ Visual Studio solution contains a _Portable Class Library_ project, a .NET 4 project for the class that cannot be represented in PCL, and a unit test project. The PCL library _EvilDICOM.Core_ supports the following targets:

* .NET Framework version 4 and higher
* Silverlight version 4 and higher
* Windows Phone version 7 and higher
* Xbox 360
* Windows Store Applications (a.k.a. Metro or Windows 8 applications)

The exact same source code can also be incorporated in a class library targeting _Mono for Android_ ( _Xamarin.Android_ ) or _Monotouch_ ( _Xamarin.iOS_ ).

Public API Differences
----------------------

To meet the requirements of a _Portable Class Library_ project, the PCL library public API differs from Rex Cardan's original _.NET 4_ library as follows:

* `DICOMBinaryReader` and `DICOMBinaryWriter` constructors, `DICOMFileReader.Read`, `DICOMFileReader.ReadFileMetadata` and `DICOMFileWriter.WriteLittleEndian` methods takes a `Stream` argument instead of file path `string`.
* `DICOMNetworkBinaryReader` is excluded in the PCL library due to its dependency to the `Socket` class. This class is instead incorporated in the .NET 4 class library _EvilDICOM.Desktop_.

PCL example usage
-----------------

Read a DICOM file with the name `path`:

    var dcm = DICOMFileReader.Read(File.OpenRead(path));			// .NET and Silverlight elevated trust applications

Write DICOM object `dcm` to a file with the name `path`:

    DICOMFileWriter.WriteLittleEndian(File.OpenWrite(path), dcm);	// .NET and Silverlight elevated trust applications
