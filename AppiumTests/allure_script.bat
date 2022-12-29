xcopy /e .\bin\Debug\netcoreapp3.1\allure-results .\allure-results\

set YYYYMMDD=%DATE:~10,4%_%DATE:~4,2%_%DATE:~7,2%
set HSMS=%TIME:~0,2%_%TIME:~3,2%_%TIME:~6,2%
xcopy /e .\bin\Debug\netcoreapp3.1\allure-results .\all-results\%YYYYMMDD%__%HSMS%\allure-results\
allure serve
