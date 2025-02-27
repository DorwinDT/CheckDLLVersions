# CheckDLLVersions

simple tool for check referenced .NET DLL's in folder and show conflicts.

tool doesn't check recursively

## sample

There is sample app and checkdllversions tool prints:
```
DLL version conflict for: System.Buffers
  Version: 4.0.3.0
    Referenced in: testDLL.dll
  Version: 4.0.4.0
    Referenced in: testApp1.exe
```

Base of result you can see, that althoug both files referencing System.Buffers, both with different version...
