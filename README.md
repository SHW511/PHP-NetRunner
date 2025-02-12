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
 - Update Visual Studio (Community) 2022 to the latest version using the Visual Studio Installer.
 - Modify your installation of Visual Studio and navigate to "Individual components" and check ".NET 8 Runtime".
 - Wait for installation to finish.
 
#### Running PhpMyAdmin and MySql
The PHP Net Runner comes with a fully functional PhpMyAdmin environment! But it comes with its own dependencies.

## Installation MySql
Install the MySQL server:
https://dev.mysql.com/downloads/installer/ 

You can leave the default settings as is, but don't forget to set a proper password for the root user!

### Optional: MySql Workbench
If you want to acces your MySql database outside of PhpMyAdmin, you can use MySql Workbench, a professional DB Management tool.
https://dev.mysql.com/downloads/workbench/ 

# How to use
No matter where you extracted the PHP Net Runner, creating a new site is easy!
<ol>
    <li>Go to wherever you extracted the PHP Net Runner and navigate to the folder named <code>PHP_Content</code> folder.</li>
    <li>Create a new folder and give it an appropriate name. This folder will act as your new <code>wwwroot</code>/<code>webroot</code>.</i>
    <li>Paste your website scripts and assets into that folder.</li>
    <li>On the index page of the PHP Net Runner, press the <code>"Reload PHP directories"</code> button.</li>
</ol>

## Productivity tip
When working with PHP projects, you should open your editor targeted at your site-directory (your <code>wwwroot</code>/<code>webroot</code>). 
This way, you can immediately see any changes you made when reloading the webpage.

See the images below as reference below on how to set up your file-structure.

![alt text](docs-assets\image.png)

![alt text](docs-assets\image-2.png)

# Bugs
Got bugs or missing features? Submit a bug-report on GitHub (https://github.com/SHW511/PHP-NetRunner/issues).

