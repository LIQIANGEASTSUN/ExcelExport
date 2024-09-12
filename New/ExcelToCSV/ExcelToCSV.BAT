
REM @echo off

REM set curdir=%~dp0
REM set exepath="%curdir%EXE\ReadExcel.exe"
REM set savepath="%curdir%CSV"
 
REM EXE路径
set exepath= %~dp0ExcelToCSV\ReadExcel\bin\Debug\ReadExcel.exe


REM 表路径
set filepath= %~dp0Table
echo %filepath%

REM 导出路径
set savepath= %~dp0Export
echo %savepath%

for /f "delims=" %%i in ('dir /s/a-d /b *.xlsx') do %exepath% %savepath% %%i

pause