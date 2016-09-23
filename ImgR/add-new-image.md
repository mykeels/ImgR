**Add New Image** [[Back]](Api-Docs.md)
----

_API Endpoint to upload a new Image's data as a Temporary Image awaiting confirmation_

* **URL**

  _~/api/images/add_

* **Method:**

    `POST`

* **Content-Type**

    `multipart/form-data`

* **Data Params**

  _This EndPoint requires that the file be pushed as HTML Form data_

* **Success Response:**
  
  * **Code:** 200 <br />
    **Content:** 
 
    ```json
        {
          "Message": "cxjvlymdrew",
          "Data": {
            "Width": 853,
            "Height": 640,
            "ID": 0,
            "OwnerID": 0,
            "OwnerType": 0,
            "URL": "~/images/cxjvlymdrew.jpg",
            "Category": "",
            "Title": "",
            "Description": "",
            "ResizeOf": 0,
            "BackupOf": 0,
            "CreationTime": "2016-09-19T16:24:14.88",
            "Active": true,
            "ResizeForDevices": false,
            "TargetDevice": 4,
            "ResizeDevice": 0,
            "Name": "cxjvlymdrew",
            "Extension": "jpg",
            "Data": null
          },
          "Status": true
        }
    ```

* **Error Response:**

  * **Code:** 400 Bad Request
  * **Content:** 

    ```json
        {
          "Message": "HttpRequest should not be NULL",
          "Data": null,
          "Status": true
        }
    ```

  * **Code:** 406 Not Acceptable
  * **Content:** 

    ```json
        {
          "Message": "HttpRequest contains no files",
          "Data": null,
          "Status": true
        }
    ```

* **Sample Call:**

   _Ermmm, coming soon!_

* **Notes:**

  _The tilde(~) in the urls should be replaced with the application root path._ 

  _If you intend to use ImgR as an Image Server for multiple Applications, each category could represent an Application Name or ID._ 



# ![ImgR Logo](https://github.com/mykeels/ImgR/blob/master/ImgR/Content/logo.png?raw=true) .NET