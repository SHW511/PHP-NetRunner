# What is PHP Net Runner
PHP Net Runner is an experiment to host the PHP Runtime (combined with a basis implementation of PhpMyAdmin) in a .NET environment.
This project is primarially aimed towards students who have trouble running XAMP for various reasons.

## A .NET wrapper
Students sometimes need to be shown the magic of programming, and the possibilities that come with it! The wrapper is a Blazor WebApp, hosting a localized PHP runtime. Therefore, code for the wrapper is publically available.

When first running this project, you will be greeted by a default Blazor Index page. Here you will find the currently assigned ports that you can navigate to.

## Caution
When closing the app, be sure to terminate the console! The console keeps ports reserved for PHP and PhpMyAdmin.

## Making PHP Assignments
The easiest way to make PHP assignments, is by adding your PHP files in the PHP_Content folder, which you can then navigate to using Blazor's index page.

# Installation
Update Visual Studio (Community) 2022 to the latest version using the Visual Studio Installer.
Modify your installation of Visual Studio and navigate to "Individual components" and check ".NET 8 Runtime".
Wait for installation to finish.
Running PhpMyAdmin and MySql
The PHP Net Runner comes with a fully functional PhpMyAdmin environment! But it comes with its own dependencies.

## Installation MySql
Install the MySQL server:
https://dev.mysql.com/downloads/installer/ 

You can leave the default settings as is, but don't forget to set a proper password for the root user!

### Optional: MySql Workbench
If you want to acces your MySql database outside of PhpMyAdmin, you can use MySql Workbench, a professional DB Management tool.
https://dev.mysql.com/downloads/workbench/ 
