These are the instructions for testing this application : 

The application converts csv files to json files and takes in 2 parameters : the filepath and the file extension we are converting to.
They are named FilePath and ConvertTo and they can be used as follow

-FilePath=C:\TestFiles\Test.csv -ConvertTo=json

In order to test this application set the 2 parameters in the command line arguments. 
	Right click on the console app (FileConverterApp) and go to properties then set the parameters in the command line arguments under debug as followed
		-FilePath=YourFilePath -ConvertTo=json
    Make sure you test file has been created in the directory you've provided in the filepath parameter.
	
After running the application the json file is created is the same directory the csv file is. 
	