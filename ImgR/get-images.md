**Get Images** [[Back]](Api-Docs.md)
----

_Get a List of Image Data based on search/filter criteria_

* **URL**

  _~/api/images_

* **Method:**

  `GET`
  
*  **URL Params**

   **Required:**

   There are no required parameters. However, when you have a large amount of images, filtering by category is probably a better choice than getting a list of thousands of images. `#justsaying`

   **Optional:**

   `?onlyActive={bool}`
   
   _When set to `true`, the `onlyActive` field determines whether the system filters out only Active Images to be rendered, or not. by default, it is set to `true`_

   `ownerType={integer}`

   _In an Application, the owner type represents the a specific image owner e.g. in a Student Records Application, we could have the following Owner Types:_

   - Students (1)
   - Dormitories (2)
   - Courses (3)

   _So, an Image with owner type value as (1) indicates that it is a student's Image.__

   `ownerID={long}`

   _When the owner type is set, you might want to narrow down to a specific owner using its ID. In the Student Records example given above, the owner id represents a student's ID._

* **Success Response:**

  * **Code:** 200 <br />
    
  * **Content:** 

    ```json
        [
          {
            "Width": 2880,
            "Height": 1800,
            "ID": 6,
            "OwnerID": 0,
            "OwnerType": 0,
            "URL": "~/images/xejgvomlzfs.jpg",
            "Category": "animals",
            "Title": "Jungle King (Edited)",
            "Description": "",
            "ResizeOf": 0,
            "BackupOf": 0,
            "CreationTime": "2016-09-19T13:52:06.43",
            "Active": true,
            "ResizeForDevices": true,
            "TargetDevice": 4,
            "ResizeDevice": 0,
            "Name": "xejgvomlzfs",
            "Extension": "jpg",
            "Data": null
          },
          {
            "Width": 480,
            "Height": 300,
            "ID": 7,
            "OwnerID": 0,
            "OwnerType": 0,
            "URL": "~/images/xejgvomlzfs-iph-3g.jpg",
            "Category": "animals",
            "Title": "Jungle King (Edited)",
            "Description": "",
            "ResizeOf": 6,
            "BackupOf": 0,
            "CreationTime": "2016-09-19T13:52:06.78",
            "Active": true,
            "ResizeForDevices": false,
            "TargetDevice": 4,
            "ResizeDevice": 1,
            "Name": "xejgvomlzfs-iph-3g",
            "Extension": "jpg",
            "Data": null
          }
        ]
    ```
 

* **Sample Call:**

  
    - JavaScript
    ```js
        $.get("~/api/images")
            .success(function (response) {
                        console.log(response);
                    })
            .error(errorhandler);
    ```

    - CSharp (via **Extensions.Api**)
    ```csharp
        Api.GetAsync<List<ImgR.Models.Image>>("~/api/images").Success((response) =>
            {

            }).Error((Exception ex) =>
            {
                Console.WriteLine(ex.Message);
            });
    ```

* **Notes:**

  _The tilde(~) in the urls should be replaced with the application root path._ 

<div style="text-align:center;margin-top:50px;">

# ![ImgR Logo](https://github.com/mykeels/ImgR/blob/master/ImgR/Content/logo.png?raw=true).NET

</div>