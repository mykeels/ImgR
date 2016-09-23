**Get Categories** [[Back]](Api-Docs.md)
----

_Need to get all Categories of Images stored on ImgR? This is the API Endpoint for you._

* **URL**

  _~/api/images/categories_

* **Method:**
  
  _application/json, text/json, application/xml, text/xml_

  `GET`

* **Success Response:**

  * **Code:** 200 <br />
  *  **Response Body:** 

    ```json
        ["animals", "cars", "greek", "liquids", "trees"]
    ```

* **Sample Call:**

    - JavaScript
    ```js
        $.get("~/api/images/categories")
            .success(function (response) {
                        console.log(response)
                    })
            .error(errorhandler);
    ```

    - CSharp (via **Extensions.Api**)
    ```csharp
        Api.GetAsync<List<string>>("~/api/images/categories").Success((response) =>
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