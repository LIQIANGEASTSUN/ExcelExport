
@echo on

echo "ExcelExport"

REM 当前路径

set curdir=%~dp0
echo curdir = %curdir%

set exePath=%curdir%ExcelExport\ExcelExport\bin\Release
echo exePath = %exePath%

set exeFileName=%ExcelExport.exe%

set filePath=%curdir%Table
echo filePath = %filePath%

set savePath=%curdir%ExportResult
echo savePath = %savePath%

start /d %exePath% ExcelExport.exe %filePath% %savePath%

echo AAAAAAA