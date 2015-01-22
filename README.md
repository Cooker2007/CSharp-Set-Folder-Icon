Inventory Management

I made the program as self-documenting as possible.

I implemented the program as a MVC without the View. The user selects what to do from the main menu then the Process calls the method.

The data is stored in a Class called TestData. In each Class I made a method to create a test data object. The CreateTestData method in TestData is called at the beginning of the program to prepopulate the program.

When a user needs to select an object, the (Class Name)Search method is used the the Id is passed to the (Class Name)ByNumber method to return the actual object.
