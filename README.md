# PollSurveyApp

This is a API database for a company/busines's internal questionaires and surveys. 

Database also stores company employee's profile for access. Profile are limited to only 

company emails and password used for access to survey dababase. NO PERSONAL INFORMATION

## Description

An in-depth paragraph about your project and overview of use.

## Getting Started

### Dependencies

* ex. Visual Studio Community
* ex. Windows 10

### Installing

* How/where to download your program
* Any modifications needed to be made to files/folders

### Executing program

* How to run the program
* Step-by-step bullets
```
code blocks for commands
```
###Endpoints

* Account
   * GET api/Account/userInfo - Allows a registered user to login using a remote provider (google, iOs). The GET will require login to Provider before access.
   * POST api/Account/Logout - Allow user to Logout of account.
   * GET api/Account/ManageInfo?returnUrl={returnUrl}&generateState={generateState} - The Get is in relationship with GET api/Account/UserInfo
   * POST api/Account/ChangePassword - Allows account user password to be changed
   * POST api/Account/SetPassword - Setup for new user password
   * POST api/Account/AddExternalLogin - Generates external Access Token
   * POST api/Account/RemovelLogin - Allows for the removal of external LoginProvider and ProviderKey
   * GET api/Account/ExternalLogin?provider={provider}&error={error} - Will give an error if Provider keyin is wrong.
   * GET api/Account/ExternalLogins?returnUrl={returnUrl}&generateState={generateState} - Authernication of external token for login
   * POST api/Account/Register - Register account for new users
   * POST api/Account/RegisterExternal - using user's Email to register with external provider. generating user ID and Login.

* Department
   * GET api/Department - Internal use only. DO NOT USE

* Survey
   * POST api/Survey - Allows Admin to tag survey/polling to Data Table.
   * GET api/Survey - Will generate a table/list of all survey/polling input from POST
   * GET api/Survey?surveyId={surveyId} - Will produce survey/polling register by ID generated from POST
   * PUT api/Survey - Allow's for Survey/Polling generated from GET ID to edit and save changes
   * DELETE api/Survey?surveyId={surveyId} - Allow's for Survey/Polling generated from GET ID to be deleted and removed.

* Category
   * GET api/Category - Internal use only. DO NOT USE

* Admin
   * POST api/Admin -  Create a new account user
   * GET api/Admin - Allows for table/list of all user accounts
   * GET api/Admin/{id} -  Will produce user account by POST generated ID
   * PUT api/Admin - Allow to edit user account by POST ID
   * Delete api/Admin/{id} - CURRENTLY NOT AVAILABLE
   
## Help

Any advise for common problems or issues.
```
command to run if program contains helper info
```

## Authors

Contributors names and contact info

ex. Lenore Brown

ex. Mansa SamLafo

ex. Shirisha Bongu

ex. Eric Bella

ex. Genevieve Meadows

ex. Erika Johnson

ex. Jared Wooten

ex. Xzavier Dunn

ex. Matt McKinney

## Version History

* 0.2
    * Various bug fixes and optimizations
    * See [commit change]() or See [release history]()
* 0.1
    * Initial Release

## License

This project is licensed under the [NAME HERE] License - see the LICENSE.md file for details

## Acknowledgments

Inspiration, code snippets, etc.
