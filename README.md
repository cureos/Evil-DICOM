Portable Evil DICOM - A DICOM library in C#
===========================================

Copyright (c) 2011-2013 Rex Cardan, Portable Class Library adaptation (c) 2012-2013 Anders Gustafsson, Cureos AB

This project is a Portable Class Library adapted fork of Rex Cardan's original [Evil DICOM](https://github.com/rexcardan/Evil-DICOM) library. 
For general information and tutorials, see [here](http://evildicom.rexcardan.com/).

Applicability
-------------

The _EvilDicom.Core_ Visual Studio solution contains a _Portable Class Library_ project and a unit test project. The PCL library supports the following targets:

* .NET Framework version 4 and higher
* Silverlight version 4 and higher
* Windows Phone version 7 and higher
* Xbox 360
* Windows Store Applications (a.k.a. Metro or Windows 8 applications)

The same source code can also be applied in a class library targeting _Mono for Android_ or _Monotouch_.

Public API Differences
----------------------

To meet the requirements of a _Portable Class Library_ project, the PCL library public API differs from Rex Cardan's original _.NET 4_ library as follows:

* `DICOMBinaryReader` and `DICOMBinaryWriter` constructors, `DICOMFileReader.Read`, `DICOMFileReader.ReadFileMetadata` and `DICOMFileWriter.WriteLittleEndian` methods takes a `Stream` argument instead of file path `string`.
* `DICOMNetworkBinaryReader` is excluded due to its dependency to the `Socket` class.
