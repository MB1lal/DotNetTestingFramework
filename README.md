# DotNet Testing Framework

This project is a unit testing framework that uses NUnit, RestSharp and Selenium to verify the functionality of various APIs and web browser interactions.

## Table of Contents

- [Introduction](#introduction)
- [Prerequisites](#prerequisites)
- [Setup](#setup)
  - [1. Clone the Repository](#1-clone-the-repository)
  - [2. Set Up Dependencies](#2-set-up-dependencies)
  - [3. Configuration](#3-configuration)
- [Running Tests](#running-tests)
  - [Selenium Tests](#selenium-tests)
  - [API Tests](#api-tests)
- [Test Reports](#test-reports)

## Introduction
This is a testing project which uses NUnit for testing both UI and API tests.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [WebDriver](https://www.selenium.dev/documentation/en/webdriver/driver_requirements/#quick-reference)

## Setup

Nuget restore the packages for setting the project up.

### 1. Clone the Repository

	```git clone https://github.com/mb1lal/DotNetTestingFramework.git```

### 2. Set Up Dependencies
Navigate to the project root and run:
	
	```dotnet restore```

### 3. Configuration
ToDo

## Running Tests
	
	```dotnet test```

### 1. Selenium Tests

	```dotnet test --filter Category=Selenium```

### 2. API Tests

	```dotnet test --filter Category=Api```

## Test Reports
Test reports are generated using Allure [ToDo]


