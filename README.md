
<a name="readme-top"></a>
<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#main-system-components">Main System Components</a></li>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contact">Contact</a></li> 
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project :  
<p>Empowering the relationship between creator and their communities.</p>
 
<img src="https://github.com/Bloomly-xyz/campaign-manager/blob/backend/Images/Nexum-image.png" alt="product" style="max-width: 100%;" /> 

Up until now, there are thousands of NFT projects in the market, some successful and some rug pulls. The missing piece is the value or utility it provides. The successful drops share their utility in discord or twitter posts. If you’re not waking up and tweeting #wagmi you’re missing out. This is where our campaign manager comes in. It attaches utility to your nft collection and presents it to your community who can then claim it. Once claimed, the creator can provide further value to the community based on their engagement and the community stays up to date by receiving notifications thus no longer having to scroll thru feeds & tons of messages
 
<p align="right">(<a href="#readme-top">back to top</a>)</p>
 
## Main System Components:
* **Cloud Flare**: Cloud flare may be used to have easy access to HTTPS and a certificate, and also to prevent DDOS.
* **Web Servers**: Are the list of web servers that run the Bloomly web application and serve user HTTP requests.
* **Cache**: A cache is used to store frequently requested data. All data that is changed has to have its corresponding cached data invalidated.
* **Relational Database**: Stores all data that is non-critical, and also serves as a persistent “second layer” caching mechanism for data stored inside the blockchain.  All data changed in the blockchain has to have its corresponding copy in the database updated.
* **Blocto Cloud Wallet**: Stores user data and user private keys. 
* **CDN**: Stores images for quicker retrieval. 
* **Cloud S3 Bucket**: Stores images and data with redundancy. 

### Built With
Given below is the tech stack we have used in our application. 

* <a href="https://dotnetcore.org/"><image src="https://github.com/Bloomly-xyz/campaign-manager/blob/backend/Images/DotNet.png" width="5%"/></a>
* [![React][React.js]][React-url]
* [![Bootstrap][Bootstrap.com]][Bootstrap-url]
* [![JQuery][JQuery.com]][JQuery-url]
* <a href="https://flow.com//"><image src="https://github.com/Bloomly-xyz/campaign-manager/blob/backend/Images/flow.png" width="5%"/></a> 

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started
1. Clone the repo
   ```sh
   git clone https://github.com/Bloomly-xyz/campaign-manager.git
   ```
2. Install NPM packages
   ```sh
   npm install
   ```

### Prerequisites

* npm
  ```sh
  npm install npm@latest -g
  ```

### Installation

1. Create .Env file in a backedn application
2. Add following keys in the .Env file 
  ```sh
    #Connection String
    ENVIRONMENT="DEVELOPMENT"
    #ENVIRONMENT="QA"
    #ENVIRONMENT="STAGING"
    #ENVIRONMENT="PROD"
    #ENVIRONMENT="LOCALHOST"
    DEFAULTCONNECTION = "DB Connection string"
    
    #AWS S3 and Secret Manager Section
    AccessKey= "Access Key"
    SecretAccessKey= "Secret Access Key"
    Region= "Region"

    #Api Key
    XApiKey= "API security key here"
 ```
 

3. Enter your API in `.Env`
   ```sh
    XApiKey = 'ENTER YOUR API';
   ```
4.  Add Datbase connection string in `.Env`
   ```sh
     DEFAULTCONNECTION = "DB Connection string"
   ```
5.  As we are using an entity framework "code first" approach you to have to run a few migrations.
   ```sh
    a. create-migration CreateNewDatabase
    b. update-database
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- USAGE EXAMPLES -->
## Usage

The nft utility industry has enjoyed some incredible success, however it suffers greatly with respect to tracking and communicating important brand utilities associated to nft collections. Imagine a person with hundreds of nfts that have ongoing utility ranging from physical, experiential and/or digital utility. How could someone keep up with all the redemptions offered with each nft?

Nexum solves this problem with a  two-ended solution. The first being an organized approach for any brand or creator to create and track utility against any collection and its respective community. Imagine a brand creator knowing who their most influential community members are thus allowing them to further incentivize their prowess? 

From a community standpoint, Nexum eliminates the need to run to discord, twitter or other social platforms to find out the status of your utilities. It’s a hub that  tethers together and organizes your utilities across various collections by providing reminders, updates and notification so you never miss a V.I.P event or important date. 

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] R&D
- [x] Initial Smart Contract
- [x] Physical Utility 
- [x] Backend Code Setup
- [x] Frontend Code Setup 
- [ ] Experiencial Utility
- [ ] Digital Utility
- [ ] Customize Theams for creators
- [ ] Cross Domains SmartContract 
	- [ ] ETH Blockchain 
	- [ ] WAX Blockchain
	- [ ] Solana Blockchain
 
<p align="right">(<a href="#readme-top">back to top</a>)</p>




<!-- CONTACT -->
## Contact

Email us on -  nasir@bloomly.xyz

 
<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES --> 
[product-screenshot]: images/screenshot.png

[Dotnet]: https://github.com/Bloomly-xyz/campaign-manager/blob/backend/Images/DotNet.png?style=for-the-badge&logo=react&logoColor=61DAFB
[Dotnet-url]: https://dotnetcore.org/
[React.js]: https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://reactjs.org/
[DotNetCore_image]: https://github.com/simple-icons/simple-icons/blob/develop/icons/dotnet.svg
[DotNetCore-url]: https://dotnetcore.org/
[Bootstrap.com]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[Bootstrap-url]: https://getbootstrap.com
[JQuery.com]: https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
[JQuery-url]: https://jquery.com 
