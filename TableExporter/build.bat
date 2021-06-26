@echo off

:: ���̽� ��ġ ���.
set MODULE_PATH=C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python37_64\Scripts

:: ������Ʈ ���.
set PROJECT_PATH=%cd%

:: ���� ������� ��µ� ���.
set BUILD_PATH=%PROJECT_PATH%\Build

:: ���� ����� ��ũ��Ʈ ���.
set SCRIPT_NAME=TableExporter.py

:: ���α׷� �̸�
set APP_NAME=TableExporter

C:
cd %MODULE_PATH%
md %BUILD_PATH%\Spec
md %BUILD_PATH%\Work

pyinstaller^
 --onefile %PROJECT_PATH%\%SCRIPT_NAME%^
 --specpath %BUILD_PATH%\Spec^
 --distpath %BUILD_PATH%^
 --workpath %BUILD_PATH%\Work^
 --name %APP_NAME%

rmdir /s/q %PROJECT_PATH%\__pycache__

pause