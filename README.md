# AlexaBuildCodeSkill
Allows Amazon Alexa to build code by communicating with a configurable Jenkins endpoint

## Setup Instructions

For local development:
appsettings.json should have the following keys in it with associated values:

JenkinsBaseUri (i.e. http://jenkins.whatever.com)

JenkinsAuthenticationToken (Found on the job you wish you build.)

JenkinsUserName (Your jenkins username)

JenkinsApiKey (Your API key, found in your user profile. This serves as a password for authenticating requests using HTTP Basic Auth.)

For production:
I recommend using an Azure App Service to host this skill. In your App Service configuration, navigate to "Application Settings" and supply the same 4 keys mentioned above, then hit save.

## Issues
Feel free to open an Issue on GitHub, or email me at me [at] bakatz.com.
