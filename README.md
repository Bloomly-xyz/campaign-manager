
<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="https://github.com/Bloomly-xyz/campaign-manager/blob/main/Images/nexum%20logo.png" alt="Logo" >
  </a>

  <h3 align="center">Empowering the relationship between creator and their communities</h3>

   
</div>


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
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contact">Contact</a></li> 
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project:  
<p>The nft utility industry has enjoyed some incredible success, however it suffers greatly with respect to tracking and communicating important brand utilities associated to nft collections. Imagine a person with hundreds of nfts that have ongoing utility ranging from physical, experiential and/or digital utility. How could someone keep up with all the redemptions offered with each nft?

Nexum solves this problem with a  two-ended solution. The first being an organized approach for any brand or creator to create and track utility against any collection and its respective community. Imagine a brand creator knowing who their most influential community members are thus allowing them to further incentivize their prowess? 

From a community standpoint, Nexum eliminates the need to run to discord, twitter or other social platforms to find out the status of your utilities. It’s a hub that  tethers together and organizes your utilities across various collections by providing reminders, updates and notification so you never miss a V.I.P event or important date. </p>
 
<img src="https://github.com/Bloomly-xyz/campaign-manager/blob/main/Images/Bloomly%20-%20Hackathon.png" style="max-width: 100%;" /> 
 
<p align="right">(<a href="#readme-top">back to top</a>)</p>

## 🎬 Live Demo of [Nexum][Nexum-url]
Check out the live demo of [Nexum][Nexum-url], deployed on the Flow Testnet. The demo involves the creator attaching a physical utility to their collection. The creator can also utilize the NBA Top Shot contract, which has been cloned for demo purposes only. Currently, the platform allows for attaching a physical utility and creating a claim page. Those who are part of the collection can then claim the utility.

 
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
* <a href="https://flow.com"><image src="https://github.com/Bloomly-xyz/campaign-manager/blob/main/Images/Flow.com_wordmark_BlackText.png" width="12%"/></a> 

<p align="right">(<a href="#readme-top">back to top</a>)</p>
 

<!-- GETTING STARTED -->
## Getting Started

1. Install Dependencies <br/>
🛠 This project requires NodeJS v18.x or above. See: [Node installation instructions][Node-url] <br/>
🛠 This project requires flow-cli v46.0 or above. See: [Flow installation instructions][FlowCLI-url] <br/>
🛠 This project requires Dotnet core 6.0 above. See: [Dot Net Core installation instructions][DotNetCore-Version_url] <br/>


## Our Product Breakdown
 1. [Backend Code Repo][Backend-Code Repo] 
 2. [Frontend Code Repo][Frontend-Code-Repo]
 3. [Cadence Smart Contract][Cadence-Smart-Contract]
  
<p align="right">(<a href="#readme-top">back to top</a>)</p>

 

<!-- ROADMAP -->
## Roadmap

- [x] R&D on initial product 
- [x] Meta View Standard Smart Contract 
- [x] Physical Utility Integration 
- [x] Backend Code Setup
- [x] Frontend Code Setup
- [x] Dynamic physical utility claim page 
- [ ] Digital & Experiencial Utility Integration 
- [ ] Integration within the Bloomly product
- [ ] Social media stats & community score
- [ ] Bloomly creators community
- [ ] Mobile Application
- [ ] A marketplace specific to utilities (Physical, digital & experiential)
- [ ] Multichain SmartContract 
 
<p align="right">(<a href="#readme-top">back to top</a>)</p>

 
<!-- CONTACT -->
## Contact

Email us on -  nasir@bloomly.xyz (Team Lead, [Flow Ambassador][Flow-Ambassador])

 
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
[FlowCLI-url]: https://developers.flow.com/tools/flow-cli
[DotNetCore-Version_url]: https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net70
[Node-url]: https://nodejs.org/en/download/
[Flow-Ambassador]: https://flowambassadors.notion.site/Meet-Flow-Ambassadors-964a10f130394128b7e767ecd4d4e733
[Nexum-url]: https://nexum.bloomly.xyz/login
[Backend-Code Repo]: https://github.com/Bloomly-xyz/campaign-manager/tree/main/backend
[Frontend-Code-Repo]: https://github.com/Bloomly-xyz/campaign-manager/tree/main/frontend
[Cadence-Smart-Contract]: https://github.com/Bloomly-xyz/campaign-manager/tree/main/contract
