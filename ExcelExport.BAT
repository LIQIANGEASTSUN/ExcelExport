
@echo off

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

REM 检查是否至少提供了一个参数, 传递的参数只能是 excel 文件路径，如果传递了 excel 文件路径，则只导出这一个文件
if "%~1" == "" (
    start /d %exePath% ExcelExport.exe %filePath% %savePath%
) else (
	start /d %exePath% ExcelExport.exe %1 %savePath%
)

REM 暂停以便查看输出结果
PAUSE
