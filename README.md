# The Flour Shop

#### A console application for a bakery to provide the user prompts for purchasing products, 27-Sept-2019

#### By **Christine Frank**

## Description

This is a console application which welcomes the user to The Flour Shop and provides product prices. The user can input the quantity of the products, and the application will return the total cost of the order.

## Setup/Installation Requirements

* Clone this repository to your desktop
* Install .NET Core SDK (if not already installed)
* Install REPL *dotnet script* (if not already installed)
    * Command: 'dotnet tool install -g dotnet-script'
* Open a new Command Terminal and route to the root of the local repository
* Enter command 'dotnet run' into the Terminal


## Known Bugs

None known at this time.

## Support and contact details

Find a bug?! Add an issue to the GitHub Repo.
Repo: https://github.com/christinelfrank16/the-flour-shop

Other Contact
Email: christine.braun13@gmail.com
LinkedIn: https://www.linkedin.com/in/christine-frank/

## Application Specifications

| Behavior | Input | Output |
|:-----|:-----:|:-----:|
|The application displays a welcome prompt upon first start of app |*User starts app*| "Welcome to The Flour Shop! "|
|The application displays a product costs with welcome prompt upon first start of app |*User starts app*| "Welcome to The Flour Shop! "<br>"Our product prices are: Bread $2 each, Pastry $1 each" |
|The application accepts positive numeric user input to specify the quantity of products they'd like | 2 Bread | Adds 2 Bread to order |
|The application returns the total cost of the order when the user indicates they would like to checkout |"Checkout"| "You ordered:<br> 2 Bread<br> Your total is: $2"|
|The application returns a good-bye prompt after checkout has been completed |"Checkout" |-order summary-<br>"Good-bye! See you again soon!"|

## Technologies Used

* C#

### License

*This application is licensed under the MIT license*

Copyright (c) 2019 **Christine Frank**
