**Describe the network protection controls used by your organization to restrict public access to databases, file servers, and desktop/developer endpoints.**
- Access to the Amazon Aurora database through the network is disabled and standard ports are closed. The database is only accessible through a socket on the server itself.
- The reverse proxy only serves whitelisted directories that are only from sources controlled by us used (AWS Amplify).
- API endpoints are password protected (PBKDF2 & SHA512 encryption, salted, and stretched for thousands of rounds).
- Login credentials are always transmitted securely over SSL.

**Describe how your organization individually identifies employees who have access to Amazon Information, and restricts employee access to Amazon information on a need- to-know basis.**
- If all your employees are properly assigned separate users and given only relevant access rights: Access rights are provided to employees based on their role within the company and are progressive, based on their responsibility.

For instance, salespersons only have access to their own leads/quotes (and thus no access to quotes generated through the Amazon API). A salesmanager has access to all quotes/leads for reporting purposes (including quotes generated through the Amazon API). A quote will generate a delivery order which will be accessible to a „normal“ user of the Inventory application for him to be able to print the delivery label and pack the products.

- If your employees share users or if they are given more permissions than necessary. They will be fired and be held responsible before the law for the consequences of leaking user information.

**Describe the mechanism your organization has in place to monitor and prevent Amazon Information from being accessed from employee personal devices (such as USB flash drives, cellphones) and how are you alerted in the event such incidents occur.**
- We does not allowed developers access to PII. Role-based restrictions and access rights still apply. Developers must not store PII in removable media, personal devices, or unsecured public cloud applications (e.g., public links made available through Google Drive) unless it is encrypted using at least RSA-2048 bit keys or higher. Developers must securely dispose of any printed documents containing PII.

**Provide your organization's privacy and data handling policies to describe how Amazon data is collected, processed, stored, used, shared and disposed. You may provide this in the form of a public website URL.**
1000 characters maximum

**Describe where your organization stores Amazon Information at rest and provide details on any encryption algorithm used.**
- Developers must encrypt all PII at rest using at least RSA with 2048-bit key size or higher. The cryptographic materials (e.g., encryption/decryption keys) and cryptographic capabilities (e.g. daemons implementing virtual Trusted Platform Modules and providing encryption/decryption APIs) used for encryption of PII at rest must be only accessible to the Developer's processes and services. Direct access to the database is not possible for the customer outside of UI interactions or API calls. Granular access rights control ensures that access is not shared to all users of the database.

**Describe how your organization backups or archives Amazon Information and provide details on any encryption algorithm used.**
- The entire database is backed up once a day and no longer than 30 days after order delivery and only for the purpose of, and as long as is necessary to (i) fulfill orders, (ii) calculate and remit taxes, (iii) produce tax invoices, or (iv) meet legal requirements, including tax or regulatory requirements. If a Developer is required by law to retain archival copies of PII for tax or other regulatory purposes, PII must be stored as a "cold" or offline encrypted backup (e.g., not available for immediate or interactive use). And these backups can only be retrieved by Teecom employees through support requests.

**Describe how your organization monitors, detects, and logs malicious activity in your application(s).**
- We uses automated probes on our server that report their status in Munin (an opensource monitoring tool). This tool automatically triggers alarms when probes detect values outside of their pre-defined range. We monitor (among many other things) access rates, response times, ssh connections, network activity.

**Summarize the steps taken within your organization's incident response plan to handle database hacks, unauthorized access, and data leaks.**
1. Preparation is we plan needs to detail who is on the incident response team—along with their contact info.
2. The detection and analysis is triggered when an incident has just occurred and we org needs to determine how to respond to it.
3. Containment, eradication, and recovery is revolve around containing the incident, eradicating the threat, and recovering from the attack.
4. Post-incident activities is security updates have been made, we take some time to debrief from the incident.


**How do you enforce password management practices throughout the organization as it relates to required length, complexity (upper/lower case, numbers, special character) and expiration period?**
- We're defined a guidelines for password and developers must establish minimum password requirements for personnel and systems with access to Information. Password requirements must be a minimum of eight (8) characters, contain upper and lower case letters, contain numbers, contain special characters, and rotated at least quarterly. We're using Multi-Factor Authentication.

**How is Personally Identifiable Information (PII) protected during testing?**
In during testing, employee only using stub database for test and not using Amazon Information database. And Personally Identifiable Information is encrypted when debug or logs.

**What measures are taken to prevent exposure of credentials?**
- Developers must use different passwords for different accounts and systems.
Developers must use multi-factor authentication (MFA) via Microsoft Authenticator for login to systems.
Developers must not hardcode sensitive credentials in their code, including encryption keys, secret access keys, or passwords. Sensitive credentials must not be exposed in public code repositories. 
Developers must maintain separate test and production environments.

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