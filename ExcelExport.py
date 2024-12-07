import os
import subprocess
import sys

def main():
    print("ExcelExport")

    # 获取当前路径
    curdir = os.path.dirname(os.path.abspath(__file__))
    print(f"curdir = {curdir}")

    # 设置 exe 路径
    exePath = os.path.join(curdir, 'ExcelExport', 'ExcelExport', 'bin', 'Release')
    print(f"exePath = {exePath}")

    # 设置 exe 文件名
    exeFileName = 'ExcelExport.exe'

    # 设置文件路径
    filePath = os.path.join(curdir, 'Table')
    print(f"filePath = {filePath}")

    # 设置保存路径
    savePath = os.path.join(curdir, 'ExportResult')
    print(f"savePath = {savePath}")

    # 检查是否至少提供了一个参数
    if len(sys.argv) < 2:
        # 如果没有提供文件路径参数，则导出整个文件夹
        subprocess.run([os.path.join(exePath, exeFileName), filePath, savePath])
    else:
        # 如果提供了文件路径参数，则导出指定的文件
        subprocess.run([os.path.join(exePath, exeFileName), sys.argv[1], savePath])

    # 等待用户查看输出结果
    input("Press Enter to continue...")

if __name__ == "__main__":
    main()
