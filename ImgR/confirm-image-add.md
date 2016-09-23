**Confirm Image Addition** [[Back]](Api-Docs.md)
----

_After you have uploaded an Image as a Temporary Image, You need to confirm it by providing its Information._

_This should be used only after the Image's Data has been added using [this endpoint](add-new-image.md)_

* **URL**

  _~/api/images/add/confirm_

* **Method:**

    `POST`
  
* **Content-Type**

   `application/json, text/json`
  
* **Data Params**

    ```json
        {
            "Width": 853,
            "Height": 640,
            "ID": 30,
            "OwnerID": 7,
            "OwnerType": 2,
            "URL": null,
            "Category": "animals",
            "Title": "Dogs",
            "Description": "",
            "ResizeOf": 0,
            "BackupOf": 0,
            "CreationTime": null,
            "Active": true,
            "ResizeForDevices": false,
            "TargetDevice": 4,
            "ResizeDevice": 5,
            "Name": "imagename",
            "Extension": "jpg",
            "Data": null
          }
    ```

* **Success Response:**
  
  _This returns a `ImgR.Models.Response<Image>` Object, with all details about the newly added image in its contents._

  * **Code:** 200 <br />
  * **Content:**

    ```json
        {
            "Message": "",
            "Data": {
                "Width": 853,
                "Height": 640,
                "ID": 30,
                "OwnerID": 7,
                "OwnerType": 2,
                "URL": "~/images/imagename.jpg",
                "Category": "animals",
                "Title": "Dogs",
                "Description": "",
                "ResizeOf": 26,
                "BackupOf": 0,
                "CreationTime": "2016-09-19T16:24:14.88",
                "Active": true,
                "ResizeForDevices": false,
                "TargetDevice": 4,
                "ResizeDevice": 5,
                "Name": "imagename",
                "Extension": "jpg",
                "Data": null
              },
              "Status": true
            }
    ```
 
* **Error Response:**

  * **Code:** 406 Unacceptable Request
  * **Content:** 

    ```json
        {
          "Message": "Request Values should not be NULL",
          "Data": null,
          "Status": true
        }
    ```

  * **Code:** 501 Server Error
  * **Content:** 

    ```json
        {
          "Message": "Failed To Add Image",
          "Data": null,
          "Status": true
        }
    ```

* **Sample Call:**

  - JavaScript

    ```js
        $.post("~/api/images/add/confirm", {
            "Width": 853,
            "Height": 640,
            "ID": 30,
            "OwnerID": 7,
            "OwnerType": 2,
            "URL": null,
            "Category": "animals",
            "Title": "Dogs",
            "Description": "",
            "ResizeOf": 0,
            "BackupOf": 0,
            "CreationTime": null,
            "Active": true,
            "ResizeForDevices": false,
            "TargetDevice": 4,
            "ResizeDevice": 5,
            "Name": "imagename",
            "Extension": "jpg",
            "Data": null
          })
            .success(function (response) {
                        console.log(response)
                    })
            .error(errorhandler);
    ```

* **Notes:**

  _The tilde(~) in the urls should be replaced with the application root path._ 

  _If you intend to use ImgR as an Image Server for multiple Applications, each category could represent an Application Name or ID._ 


# ![ImgR Logo](https://github.com/mykeels/ImgR/blob/master/ImgR/Content/logo.png?raw=true) .NET