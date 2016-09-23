**Get Image Information** [[Back]](Api-Docs.md)
----

_Use an Image's Name or Data to get its Information._


* **URL**

  _~/api/images/\{id}_

* **Method:**
  
  _application/json, text/json, application/xml, text/xml_

  `GET`


*  **URL Params**

   _\{id} can be the Image's Name. The Image's Name is the part of its filename, without the Directory Path and Extension_

   _\{id} can also be the Image's ID which is a Number._ 


* **Success Response:**

  * **Code:** 200 <br />
  *  **Response Body:** 

    ```json
        {
          "Message": "imagename-sm-lp",
          "Data": {
            "Width": 853,
            "Height": 640,
            "ID": 30,
            "OwnerID": 7,
            "OwnerType": 2,
            "URL": "~/images/imagename-sm-lp.jpg",
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
            "Name": "imagename-sm-lp",
            "Extension": "jpg",
            "Data": null
          },
          "Status": true
        }
    ```

* **Sample Call:**

    - JavaScript
    ```js
        $.get("~/api/images/imagename-sm-lp")
            .success(function (response) {
                        console.log(response)
                    })
            .error(errorhandler);
    ```

    - CSharp (via **Extensions.Api**)
    ```csharp
        Api.GetAsync<List<ImgR.Models.Image>>("~/api/images/imagename-sm-lp").Success((response) =>
            {

            }).Error((Exception ex) =>
            {
                Console.WriteLine(ex.Message);
            });
    ```

* **Notes:**

  _The tilde(~) in the urls should be replaced with the application root path._ 

  _If you intend to use ImgR as an Image Server for multiple Applications, each category could represent an Application Name or ID._ 



# ![ImgR Logo](https://github.com/mykeels/ImgR/blob/master/ImgR/Content/logo.png?raw=true) .NET