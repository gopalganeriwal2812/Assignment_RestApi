# Assignment_RestApi

The provided source code is refactored using Visual Studio 2017

1. Connection string under web.config file is changed to connect to local database. Please revert it to your own database path.
2. A Help controller is added to test the Web Api. 
    
    Instructions to Test
    1. On running the main project and opening of the Browser type -  http://localhost:65534/Help  ==> Portnumber will vary in your system
    2. Clicking on 'GET patients/Get/{patientId}' link will display a button 'Test API' on Right bottom corner of the browser.
    3. Clicking on button will open a dialog box to input Patient id..
    4. Input of correct patient id will fetch patient and its corresponding Episodes

3. Test project with the help of NUnity.  
    a. Web API Endpoint functionality test is written.
