# MobaXterm License Generator

Allows you to generate and activate a copy of [MobaXterm](https://mobaxterm.mobatek.net/).

# About

This is a **Private** repo with source files for this keygen.
It contains all the source files and a working solution for generating MobaXterm licenses using the base app exe, and a python .py script located in the same directory.

This solution is BEFORE using IronPython and merging all the IronPython related DLLs down into a single exe.

The issue with this version is that when you build the app, the release folder has a large number of DLL files that are required for your exe + IronPython to function.

Our goal is to get a single .exe that the end-user can click that does everything.

The other solution was to take the python `xtgen.py` script and run it through IronPython's exe, and merge the python script with Iron Python into a single exe.

This generated exe could then be added as a resource inside your core Visual Studio project, and called to spit out the license key.

To view the Python script source code that gets converted into an exe; view the [MobaXtermKeygen-Python](https://github.com/Aetherinox/MobaXtermKeygen-Python).

# Notes
Another possible solution is to merge all the DLLs using the Visual Studio nuget library **ILMerge**. I have not completely tested how this works.

The original goal was to just take the python script, merge it and the Iron Python libraries into a single .exe, and then in the main Visual Studio project, add the generated python script exe as a resource, and then call the exe when needing to generate the license key.