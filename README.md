## Description

This is a hospital management system on ASP.NET.CORE that includes scheduling, electronic medical records, auth system,and databases for doctors, patients, and administrators.


## Used Frameworks

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.UI
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.NETCore.App
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Syncfusion.DocIO.Net.Core
- Syncfusion.DocIORenderer.Net.Core

## How to start
Download all essential Framework. Also you need to upload Microsoft SQL Server Manager and make basic setting.

Open NuGet Package Console and write this commands

 	add-migration ApplicationDBContextMigration -context ApplicationDBContext
  	add-migration DoctorDbContextMigration -context DoctorDbContext
   	add-migration CommentDbContextMigration -context CommentDbContext
    add-migration ApplicationUserMigration -context ApplicationUser

	Update-Database -context ApplicationDBContext
 	Update-Database -context DoctorDbContext
	Update-Database -context CommentDbContext
 	Update-Database -context ApplicationUser

After that find Auth file and press start

Documentation 

![image](https://github.com/user-attachments/assets/9c73d0b7-3e51-4d7e-b6b1-a1016a569622)
# Screen 1 - The Authorization and Registration page.

After registration, users are immediately redirected to the main menu with the account they have just created. In the main menu, they can browse the available sections, customize their profile, and use the basic functionality of the system. The main page of the site is shown in Screen 2.

![image](https://github.com/user-attachments/assets/68b3f61f-a37b-4d0e-94ef-fc5266471669)
# Screen 2 - Home page of the website.

On the main menu bar, you can find all the information about the clinic, including the sections “About Us”, “Best Doctors”, and “Reviews”. The “About Us” section provides information about our mission and experience in the medical field, emphasizing our achievements and goals that we strive to achieve to improve the health of our patients. Below is the “Best Doctors” section, where users can find the most recommended doctors according to patient reviews. Doctors of various specialties are presented here, ranging from surgeons to general practitioners. Each doctor has his or her own profile, which includes their professional achievements, specialization, work experience, education, and patient reviews.
In the “Reviews” section, users can leave their impressions of visiting the clinic and individual doctors. Reviews help to understand how doctors work with patients, their attitude and professionalism.

Thus, the main menu serves as a kind of navigation bar that allows users to quickly access important information about the clinic, get acquainted with the best doctors and read real patient reviews, which helps in choosing a doctor and making treatment decisions. 
To view the entire list of doctors, go to the “Make an appointment” tab in the navigation menu, where a large selection of specialists is displayed with basic information such as “First name”, “Last name”, “Rating” and “Specialty”. The user also has a filtering and search function where he can filter doctors by their specialty, therapist, surgeon, pediatrician, neurologist, dermatologist, plastic surgeon, orthopedist, physical therapist, psychiatrist, ophthalmologist. In addition, he can return everything to its original state by clicking on “All”. If the user is interested in the best doctors, he or she can click on the “Top Doctors” button and filter them by rating from best to worst. The search allows you to find a specific doctor by name, surname, patronymic, or specialty. The “List of doctors” page is shown in Screen 3.

![image](https://github.com/user-attachments/assets/d4f7b834-f25d-4d27-b69c-2d8e155d48d5)
# Screen 3 - Home page of the website.

After selecting the desired doctor, you are taken to the page with information about the doctor, where you can view all the necessary information. The block on the left contains the following data: “First name:”, ‘Last name:’, ‘Patronymic:’, ‘Date of birth:’, ‘Gender:’, ‘Place of work:’, ‘Specialization:’, ‘Phone number:’, ‘Mail:’. To the right of the block is a table with a schedule where the user can choose the date and time of the appointment. The “Information about the doctor” page is shown in Screen 4.

![image](https://github.com/user-attachments/assets/58c26c9e-ef84-4b34-8243-1a79b67d889f)
# Screen 4 - Page “Information about the doctor”

Let's take an appointment with a doctor as an example. After selecting the date, a window opens where we can view the information before sending it to the doctor for review. This includes the start and end of the date and the status of the appointment. We can also add a comment if necessary. The “Confirmation of record” window is shown in Screen 5.

![image](https://github.com/user-attachments/assets/7060792f-9b17-4c42-9946-3f72f72d13d2)
# Screen 5 - The “Confirm entry” window 

In the same menu, you can view comments about this doctor and leave your own feedback. The “Patient Comments” section is shown in Screen 6.

![image](https://github.com/user-attachments/assets/316ea708-b1cc-4d36-b3be-736e542be669)
# Screen 6 - Patient comments section

After all the operations have been performed, the user can go to the main menu and use the navigation bar to find information about the appointment, where a new section will open with all the records he or she has made. It will contain information about the place of the appointment, the doctor, his/her address, photo, e-mail, and phone number in case of need to contact. The Appointment Information page is shown in Screen 7.

![image](https://github.com/user-attachments/assets/8b01e090-dbab-4a22-bbc9-40b8ea1dfa70)
# Screen 7 - The “Meeting information” page.

To log in as a doctor, the same menu is used as for a user, but with one difference: only the administrator can create a doctor. After logging in, a new tab called “Schedule” appears in the navigation menu, where the doctor can customize his or her current schedule and confirm patient records. In this menu, the doctor can add appointments, delete them, edit them, and plan his or her schedule for three months in advance, if necessary. The “Doctor's schedule” page is shown in Screen 8. 

![image](https://github.com/user-attachments/assets/7c7c006b-1fef-4aa1-b90b-61f9b507ed2e)
# Screen 8 - The “Doctor's schedule” page
After the first clients have made appointments, the doctor can go to the “Appointment Information” tab, where all patients who have made appointments with this doctor are now displayed. You can also view information about the ID card, patronymic, surname, email, gender, date of birth, address, and phone number. There are also four buttons: “View medical record”, ‘Download PDF’, ‘Add appointment’, and ‘End visit’. The “Appointment Information” tab in the doctor's account is shown in Screen 9.

![image](https://github.com/user-attachments/assets/92057ccb-0f3b-4a9a-b170-8b1d92bbf456)
# Screen 9 - Appointment Information tab in the doctor's account
To create a record, go to the “Add a record” section, where a new menu will open where you can select the type of record. There are currently four types available: “Investigation report”, ‘Medication record’, ‘Surgical and procedural record’, and ‘Current health record’. For example, fill in the “Investigation Report” where you specify the type of test, result, normal values, interpretation, and additional information. After that, click the “Send” button. The tab “Record of research results” is shown in Screen 10.

![image](https://github.com/user-attachments/assets/82ab2028-9a07-4ec1-93fb-fc40f946f63c)
# Figure 10 - The tab “Record research results”
After that, you go back to the appointment information, where you can view the medical record by clicking the appropriate button for the user whose information you want to view. A new menu will open, where the records will be displayed in the format of a Word file. Here you will see all the known information about the user. The display of the Word file of the medical record is shown in Screen 11.

![image](https://github.com/user-attachments/assets/880db68a-5d95-40f3-8c53-eb14975a89f6)
# Screen 11 - Displaying a Word file of a medical record

The last in line is the administrator. In general, all they can do is create, delete, and edit patients, filter them by various criteria, and use search. To log in, select “Authorization/Registration” on the main menu, where you enter the administrator's email and password. After that, you will be able to log in to the admin panel, where you will see all users that exist in the system. The “List of all doctors” page is shown in Screen 12.

![image](https://github.com/user-attachments/assets/e575830d-d3cc-4318-92e4-851f08f4e2f9)
# Screen 12 - List of all doctors.

