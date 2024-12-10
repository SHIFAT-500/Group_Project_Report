Certificate Generator:

Certificate Generator is a Windows application that streamlines the process of creating, 
managing, and issuing certificates for educational institutions. This project is developed 
using C# with Visual Studio and uses Microsoft SQL Server for database management.

FEATURES:

* Instant Certificate Generation: Create certificates instantly upon data entry.
* PDF Export and Printing:  Save certificates as PDF files and print them directly.
* User-Friendly Interface: Separate admin and user dashboards for efficient management.
* Error Reporting: Users can report issues with certificates directly to the admin.
* Course Management: Add students to courses and track their progress.
* Profile Notifications: Automated notifications upon certificate creation.


INSTALLATION:

Prerequisites:
* Operating System: Windows 11 or above.
Software Requirements:
* Visual Studio with .NET Framework (4.7)
* Microsoft SQL Server
  
STEPS:

1. Clone the repository:   git clone https://github.com/your-repo/certificate-generator.git
2. Open the project in Visual Studio.
  
3. Configure the database:
     * Create a new database in Microsoft SQL Server.
     * create the provided SQL schema.( check in the last section )
       
4. Update the database connection string in the configuration file.
5. Build and run the project in Visual Studio.

USAGE:

ADMIN PANEL:
* Dashboard: Manage courses, students, and certificates.
* Add Student: Register new students and assign them to courses.
* Create Certificate: Generate certificates for course completion.
* Issue Box: View and address reported issues with certificates.
  
USER PANEL:
* Dashboard: View enrolled courses and certificates.
* Take Course: Enroll in new courses.
* Profile and Certificates: Access and download personal certificates.
  
SYSTEM DESIGN:

DEVELOPMENT ENVERNMENT:
* Processor: Intel Core i5 (11th Gen)
* Memory: 8GB RAM
* Storage: 512GB SSD
  
Technologies Used:
* Programming Language: C#
* Database: Microsoft SQL Server
* Compiler: .NET Framework (4.7)
  
Special Features:
* Real-Time Generation: Generate certificates instantly.
* Profile Notifications: Notify users upon certificate creation.
* Error Reporting: Users can directly report errors for quick resolution.
  
Limitations:
* No dynamic certificate design feature.
* Barcode scanning for certificate verification is not supported.
  
Future Enhancements:
* Integrate AI to enhance user experience.
* Add more courses and dynamic certificate design options.
* Incorporate barcode scanning for enhanced certificate validation.
  
Authors:

Developed by:
Arifa Haque
Mehedi Hassan Eshan
Sumaiya Hossain
Arifur Rahman
Md. Shifat Hossain

Supervisor: Labiba Farah, Lecturer, Department of CSE, Bangladesh University of Business and Technology


Entity Relationship Diagram:

![image](https://github.com/user-attachments/assets/acb6687a-2b1a-4528-972b-00b86f0982aa)

SQL schema for creating database:

-- Create databases
CREATE DATABASE CertificateGenerator;
CREATE DATABASE Certificate_Generator2;
CREATE DATABASE Certificate_Generator3;

-- Switch to Certificate_Generator3 for addsdp and certificatesdp tables
USE Certificate_Generator3;

-- Table: addsdp
-- This table belongs to the Certificate_Generator3 database
CREATE TABLE addsdp (
    stuorder INT PRIMARY KEY,
    project_name VARCHAR(MAX),
    member_name VARCHAR(MAX),
    member_id VARCHAR(MAX),
    intake VARCHAR(MAX)
);

-- Table: certificatesdp
-- This table belongs to the Certificate_Generator3 database
CREATE TABLE certificatesdp (
    stuorder INT PRIMARY KEY,
    project_name VARCHAR(MAX),
    member_name VARCHAR(MAX),
    member_id VARCHAR(MAX),
    intake VARCHAR(MAX),
    issue_date VARCHAR(MAX)
);

-- Switch to Certificate_Generator2 for addstudentcourse and createcertificate tables
USE Certificate_Generator2;

-- Table: addstudentcourse1
-- This table belongs to the Certificate_Generator2 database
CREATE TABLE addstudentcourse1 (
    stuorder INT PRIMARY KEY,
    sname VARCHAR(MAX),
    senroll VARCHAR(MAX),
    sgender VARCHAR(MAX),
    scontact VARCHAR(MAX),
    semail VARCHAR(MAX),
    sinstitute VARCHAR(MAX),
    scountry VARCHAR(MAX)
);

-- Table: addstudentcourse2
-- This table belongs to the Certificate_Generator2 database
CREATE TABLE addstudentcourse2 (
    stuorder INT PRIMARY KEY,
    sname VARCHAR(MAX),
    senroll VARCHAR(MAX),
    sgender VARCHAR(MAX),
    scontact VARCHAR(MAX),
    semail VARCHAR(MAX),
    sinstitute VARCHAR(MAX),
    scountry VARCHAR(MAX)
);

-- Table: createcertificate1
-- This table belongs to the Certificate_Generator2 database
CREATE TABLE createcertificate1 (
    stuorder INT PRIMARY KEY,
    sname VARCHAR(MAX),
    senroll VARCHAR(MAX),
    sgender VARCHAR(MAX),
    scontact VARCHAR(MAX),
    semail VARCHAR(MAX),
    sinstitute VARCHAR(MAX),
    scountry VARCHAR(MAX),
    issue_date VARCHAR(MAX)
);

-- Table: createcertificate2
-- This table belongs to the Certificate_Generator2 database
CREATE TABLE createcertificate2 (
    stuorder INT PRIMARY KEY,
    sname VARCHAR(MAX),
    senroll VARCHAR(MAX),
    sgender VARCHAR(MAX),
    scontact VARCHAR(MAX),
    semail VARCHAR(MAX),
    sinstitute VARCHAR(MAX),
    scountry VARCHAR(MAX),
    issue_date VARCHAR(MAX)
);

-- Switch to CertificateGenerator for the remaining tables
USE CertificateGenerator;

-- Table: addstudentcourse3
-- This table belongs to the CertificateGenerator database
CREATE TABLE addstudentcourse3 (
    stuorder INT PRIMARY KEY,
    sname VARCHAR(MAX),
    senroll VARCHAR(MAX),
    sgender VARCHAR(MAX),
    scontact VARCHAR(MAX),
    semail VARCHAR(MAX),
    sinstitute VARCHAR(MAX),
    scountry VARCHAR(MAX)
);

-- Table: addstudentcourse4
-- This table belongs to the CertificateGenerator database
CREATE TABLE addstudentcourse4 (
    stuorder INT PRIMARY KEY,
    sname VARCHAR(MAX),
    senroll VARCHAR(MAX),
    sgender VARCHAR(MAX),
    scontact VARCHAR(MAX),
    semail VARCHAR(MAX),
    sinstitute VARCHAR(MAX),
    scountry VARCHAR(MAX)
);

-- Table: createcertificate3
-- This table belongs to the CertificateGenerator database
CREATE TABLE createcertificate3 (
    stuorder INT PRIMARY KEY,
    sname VARCHAR(MAX),
    senroll VARCHAR(MAX),
    sgender VARCHAR(MAX),
    scontact VARCHAR(MAX),
    semail VARCHAR(MAX),
    sinstitute VARCHAR(MAX),
    scountry VARCHAR(MAX),
    issue_date VARCHAR(MAX)
);

-- Table: createcertificate4
-- This table belongs to the CertificateGenerator database
CREATE TABLE createcertificate4 (
    stuorder INT PRIMARY KEY,
    sname VARCHAR(MAX),
    senroll VARCHAR(MAX),
    sgender VARCHAR(MAX),
    scontact VARCHAR(MAX),
    semail VARCHAR(MAX),
    sinstitute VARCHAR(MAX),
    scountry VARCHAR(MAX),
    issue_date VARCHAR(MAX)
);

-- Table: admintable
-- This table belongs to the CertificateGenerator database
CREATE TABLE admintable (
    id INT PRIMARY KEY,
    username VARCHAR(MAX),
    pass VARCHAR(MAX)
);

-- Table: issue
-- This table belongs to the CertificateGenerator database
CREATE TABLE issue (
    serial INT PRIMARY KEY,
    course_name VARCHAR(MAX),
    enroll VARCHAR(MAX),
    issue VARCHAR(MAX)
);

-- Table: usertable
-- This table belongs to the CertificateGenerator database
CREATE TABLE usertable (
    id INT PRIMARY KEY,
    username VARCHAR(MAX),
    pass VARCHAR(MAX)
);


Flowchart:

![image](https://github.com/user-attachments/assets/e5311f83-a37a-474a-b47f-0ff7ca995a8d)


PROJECT INTERFACE:

![image](https://github.com/user-attachments/assets/d8f5f6de-19f2-4041-b762-463262d8efb8)

![image](https://github.com/user-attachments/assets/64991c12-b04b-4e60-be91-d4ce57e0e7f1)

![image](https://github.com/user-attachments/assets/ec99eb24-7b57-44f3-a1b8-5dc7d321eb3d)

![image](https://github.com/user-attachments/assets/e8ced235-7951-45e0-984e-f720a44c73bb)

![image](https://github.com/user-attachments/assets/ca23db1c-d02b-4876-80e9-ecdc518815ab)

![image](https://github.com/user-attachments/assets/5dcbf336-1e6a-4e4c-b028-52ff0be28789)

![image](https://github.com/user-attachments/assets/df2b88e8-30d6-4700-98d9-15b2257fb097)

![image](https://github.com/user-attachments/assets/819fb269-e253-4d11-99ce-74382493d0e4)

![image](https://github.com/user-attachments/assets/ae5e5a86-dbc3-4e86-b626-e98b902ca80d)

![image](https://github.com/user-attachments/assets/92694576-1425-4457-a2b9-1cc4cfdfcf9e)

![image](https://github.com/user-attachments/assets/acbe9e71-a4a7-4ee2-8847-68cd13cef188)

![image](https://github.com/user-attachments/assets/e529f63e-8218-412e-be85-10a38c4cd53a)

![image](https://github.com/user-attachments/assets/575bbbf7-d193-4fa5-ad86-9ceb91f6f26f)


THANK YOU.
