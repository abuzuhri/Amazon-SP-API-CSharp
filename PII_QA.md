**Describe why you require Personally Identifiable Information to build your application or feature.**
- We are shipping internationally from our store  to  (UK) and need to automate the generation of AWBs (Air Waybills) through our system and the shipping company. To generate the AWB, we require the customer's address.
- The only purpose for using PII (Personal Identifiable Information) is to create the AWB by passing the necessary information to the shipping company's API. 




**List all outside parties with whom your organization shares Amazon Information and describe how your organization shares this information.**
- We share customer addresses with the shipping company to automate the shipping process. This is done through a customized API that generates AWB labels. We only provide the necessary information to the shipping company’s API by submitting a request from our side, which includes all required personal information (PII) to create a new AWB.


**Describe the network protection controls used by your organization to restrict public access to databases, file servers, and desktop/developer endpoints.**
- Our database server is behind a firewall Only allows connection from certain addresses IP, in addition to being protected by username and password. As for our file server, we use Azure Storage. where we also block requests through a private Key Access.



**Describe how your organization individually identifies employees who have access to Amazon Information, and restricts employee access to Amazon information on a need- to-know basis.**
- All of our employees are identified by a unique ID. accessing with username and password. that determines your role and permissions within our system. In this way, only authorized employees will have access to information from Amazon, keeping at all times the traceability of who and what information accesses


**Describe the mechanism your organization has in place to monitor and prevent Amazon Information from being accessed from employee personal devices (such as USB flash drives, cellphones) and how are you alerted in the event such incidents occur.**
- The USB connections of all computers are disabled and the use of personal email, messaging or cloud storage accounts. they are totally prohibited. We have an alert system that warns when abnormal behavior is detected when accessing sensitive information. providing the user, date and time. the IP address of the connection and the event that triggered the alarm (for example, a large number of requests to a sensitive endpoint).

**Provide your organization's privacy and data handling policies to describe how Amazon data is collected, processed, stored, used, shared and disposed. You may provide this in the form of a public website URL.**
1000 characters maximum


**Provide your organisation's privacy and data-handling policies to describe how Amazon data is collected, processed, stored, used, shared and disposed of. You may provide this in the form of a public website URL.**
- {URL}/Home/PrivacyPolicy

**Describe where your organization stores Amazon Information at rest and provide details on any encryption algorithm used.**
- We store information about personalization of the products necessary for their manufacture. This data is stored on our database server, with symmetric AES 256 encryption and is removed as manufacturing proceeds. Any resource or application that accesses this data must do so through the HTTPS protocol, to guarantee encryption in transit.


**Describe how your organization backups or archives Amazon Information and provide details on any encryption algorithm used.**
- The stored information (product customization) is included in our periodic backups. These copies are encrypted using the AES 256 algorithm and managed by Azure, including access restriction by username and password. firewall and security alerts. Backups are done in Azure. where no one has access, only the database administrator.

**Describe how your organization monitors, detects, and logs malicious activity in your application(s).**
We uses automated probes on our server that report their status in Munin (an opensource monitoring tool). This tool automatically triggers alarms when probes detect values outside of their pre-defined range. We monitor access rates, response times, ssh connections, network activity.
We gather logs information to detect security-related events and logs accessible only to developer who has permission , 
But for amazon PII we made exception for logs to exclude any PII information from logs


**Summarize the steps taken within your organization's incident response plan to handle database hacks, unauthorized access, and data leaks.**
1. Preparation is we plan needs to detail who is on the incident response team—along with their contact info.
2. The detection and analysis is triggered when an incident has just occurred and we org needs to determine how to respond to it.
3. Containment, eradication, and recovery is revolve around containing the incident, eradicating the threat, and recovering from the attack.
4. Post-incident activities is security updates have been made, we take some time to debrief from the incident.



**How do you enforce password management practices throughout the organization as it relates to required length, complexity (upper/lower case, numbers, special character) and expiration period?**
- We're defined a guidelines for password and developers must establish minimum password requirements for personnel and systems with access to Information. 
Password restrictions	
• A minimum of 12 characters 
• Requires the following: - Lowercase characters - Uppercase characters - Numbers (0-9) - Symbols
- and rotated at least quarterly before expired  
- We're using Multi-Factor Authentication.

**How is Personally Identifiable Information (PII) protected during testing?**
- If it’s necessary for a test participant’s PII to be visible on the screen during a certain task then we enable the Blur Tool to make the screen unreadable during that specific task.
- Also if data move to test database in test environment then all data for user data PII removed and to mock random data added by database admin before give access to testing user or developer in Test environments and also developer do testing and call to sandbox instead of call production


**What measures are taken to prevent exposure of credentials?**
- Passwords are hashed (with salt and IV) before being stored in our database, so If anyone can access it, they couldn't access the original passwords. Additionally, we enforce changing passwords every 6 months, to avoid other password leaks possibilities.


**How do you track remediation progress of findings identified from vulnerability scans and penetration tests?**
- We're testing our applications periodically to assess products’ security is locate any security vulnerabilities that might be hidden in source code, before releasing it.  
- We're using SonarQube (automated tracking and detecting Vulnerabilities tools) to developers automatically detect all open source components in an organization’s systems.

**How do you address code vulnerabilities identified in the development lifecycle and during runtime?**
- We're config standard automation and integration into the tools developers already use.
- We're real-time application security awareness training, within developers’ integrated development environments.
- We're using CI/CD tool to deployment.
- We're using Splunk tool to quickly detect and respond to internal and external attacks, to simplify threat management while minimizing risk, and safeguard systems.
- We're quick remediation, in the shortest time possible with best-fix location.

**Who is responsible for change management and how is their access granted? Please specify job title.**
- Security system team is responsible for change management. They access granted for developers and operators.