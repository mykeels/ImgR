# ImgR.NET

### Wharrisdis (What is this)?
Serving Images dynamically based on the client device is an important part of Web Page Resource Optimization. ImgR aims at automating the process and making it easy on both the Server CPU, Client Device and of course You, the Programmer.

ImgR is a .NET Class Library written in C# which has inheritable classes that let you manage your Website Images Effectively and Efficiently.

### Why not just compress the Image?
Image Compression is not the perfect solution because of quality loss and because:

-   Compressing for Mobile would mean that Desktop viewers would get a poor view.

-   Compressing for Desktop would mean that Mobile Viewers would get images that have qualities that are too good for mobile view.

### Why not use css to resize the Images?
CSS Resize is done on the Client Browser, meaning that the Browser has to download the Image file before resizing is done. This defeats the purpose which is to reduce the amount of data traffic needed by the web pages.

### Wow, how do I use this?
-   Add a reference to [ImgR.DLL](https://github.com/mykeels/ImgR/blob/master/ImgR/bin/Debug/ImgR.dll?raw=true) in your ASP.NET 4.5.2 MVC Project
-   You will need a folder to store your website images. For this Example, Create an Empty Folder in your application root folder called `Images`
-   Create a class in your `Controllers` Folder called `ImagesController`
-   Make `ImagesController` inherit from `ImgR.ImagesController` e.g.   
    ```cs
    public class ImagesController : ImgR.ImagesController { }
    ```

-   Create another class in your `Controllers/API` Folder also called `ImagesController`, and make it inherit from `ImgR.Api.ImagesController` e.g.
    ```cs
    public class ImagesController : ImgR.Api.ImagesController { }
    ```

-   In your Web.config, add the following in the root (`<configuration>`):

    ```xml
    <location path="images">
        <system.web>
          <httpHandlers>
            <add path="*" type="System.Web.Handlers.TransferRequestHandler" verb="GET,HEAD,POST,DEBUG,PUT,DELETE,PATCH,OPTIONS" />
          </httpHandlers>
        </system.web>
        <!-- Required for IIS 7.0 -->
        <system.webServer>
          <modules runAllManagedModulesForAllRequests="true" />
          <validation validateIntegratedModeConfiguration="false" />
          <handlers>
            <add name="ApiURIs-ISAPI-Integrated-4.0" path="*" type="System.Web.Handlers.TransferRequestHandler" verb="GET,HEAD,POST,DEBUG,PUT,DELETE,PATCH,OPTIONS" preCondition="integratedMode,runtimeVersionv4.0" />
          </handlers>
        </system.webServer>
    </location>
    ```
This will allow ASP.NET handle all requests for content within the `Images` folder

-   Also, add the following in `<AppSettings>`
    ```xml
    <add key="imgr-root-path" value="~/images/" />
    ```
This tells ImgR that `Images` is the folder to store and get images

-   Add the following in `<connectionStrings>`
    ```xml
    <add name="ImgR.Properties.Settings.ImgRConnectionString" connectionString="Data Source=DB Server Name;Initial Catalog=DB Name;User ID=DB Username;Password=DB password"
      providerName="System.Data.SqlClient" />
    ```

-   And Finally (Yea, Ikr?), Copy the `Views/Images` Folder into your `Views` Folder. This will give you the Views you need to work with ImgR. Click [here]() to download the Views as a compressed folder.

### How it works
ImgR uses a Target Device system to manage its Images. Each device possesses the following properties:
-   Name e.g. Iphone 6
-   Width e.g. 420
-   Height e.g. 680

The user adds Target Devices to the system and specifies one of the devices as the default target device. The default target device should be the device with the largest display width e.g. "*Big Screen* [1920x1080]"

Every uploaded Image should be designed with the default target device screen size as its target display.

##### Image Upload

When an Image is Uploaded, the user specifies whether or not to create resizes. If specified, copies of the original image are resized for devices with smaller screen areas than the default device. _Smaller Screen Areas are targeted to prevent Image Bloating._

##### Image Access

When an Image is accessed via its url e.g. `~/images/[image-file-name]`, the following occurs:

![ImgR Flowchart - How Image Access via Web Request works](https://raw.githubusercontent.com/mykeels/ImgR/master/ImgR/Misc/ImgR-Flowchart.png)

### Tests
Let's see how ImgR performs, yea? We have run tests using Chrome's Device Simulator and here are the results ... Drum Roll ...

Two Images are used. The first is 830 KB and the second is 3.4 MB large. These are pretty large for Web, but are the typical size for Images fresh out of Photoshop. 

##### On a Large Screen [2560x988]
On a Big 2560x988 Screen, the Images come just as they are in their original size. No attempt is made to resize or compress the images. This is done to prevent loss of quality. 

![](https://raw.githubusercontent.com/mykeels/ImgR/master/ImgR/Misc/Test-No-Resize.png)

<center><span style='color: red'>The total page size is 4.3 MB</span></center>

<br>

##### On a Laptop Screen [1366x768]
On my laptop screen, the Images are resized, and the first becomes 277 KB while the second is 683 KB. 

![](https://raw.githubusercontent.com/mykeels/ImgR/master/ImgR/Misc/Test-Resize-1366.png)

<center><span style='color: #FFAA00'>The total page size is reduced to 1.1 MB. We have saved 3.2 MB, Yaay!</span></center>

<br>

##### On an iPad [768x1024]
On a Tablet Device, the first image is 101 KB while the second is 276 KB.

![](https://raw.githubusercontent.com/mykeels/ImgR/master/ImgR/Misc/Test-Resize-768.png)

<center><span style='color: #00AAFF'>The total page size comes down to 528.3 KB. We have saved 3.8 MB, Yaaaay!!</span></center>

<br>

##### On a Galaxy S5 [360x640]
On a phone screen, the change is quite dramatic. The first image is 23.3 KB and the second is 59.4 KB.

![](https://raw.githubusercontent.com/mykeels/ImgR/master/ImgR/Misc/Test-Resize-360.png)

<center><span style='color: green'>The total page size becomes 234 KB. We have saved 4.1 MB, Yaaaaaay!!!</span></center>

<br>

### Wanna get in on this? (Contributions)
Make a pull request if you have any ideas about how ImgR can be improved. I'd love to hear from you. 

If ImgR.NET has helped you, Star this Repo. It'll help make sure ImgR.NET helps others too.

If you have suggestions, send me an email, or a [tweet](https://twitter.com/mykeels).

Thanks! Ikechi Michael I.

### Contributors
[Nimisoere Tekena-Lawson](https://github.com/nimisoere) (UI/UX) [(tweet)](https://github.com/nimimccool)

### License

ImgR.NET is licensed under the MIT License (MIT). Please see License File for more Information.