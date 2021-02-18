# C-Sharp-Group-Project
This project was created using ASP.NET MVC. The project requires users to login in order to view a course catalog. If they are an admin, they can make changes to the course catalog. If they are not an admin, then they can only view the course catalog.
## Sessions
This project uses sessions to determine if the user is an admin or not. All sessions are set to expire in a day.
## wwwroot/Static Files
So far, no changes have been made to this folder.
## Controllers
This project consists of two controllers: Courses and Catalog. The Courses controller is used to handle logins, sign ups, and allows vistors to visit the Home page. These views are: Login, Signup, and Index. The Catalog controller is used to handle the course catalog. The views in this controller are: Index, Details, Create, Edit, and Delete.
### Views
The Login view is used to display a form that allows users to login. If the user entered the correct information, then they will be taken to the Home page after submitting the form. When running this project, the first view that the user will see would be the Login view. The Signup view is used to display a form that is used to allow users to sign up for the course catalog (a.k.a create an account). If the user entered the correct information, then they will be taken to the Login view after submitting the form. The first Index view is used to display the Home page.

The second Index view is used to display all the courses in the course catalog. The Details view, on the other hand, is used to display information about each course (one at a time). There are also views (that only appear for admins) that will manipulate the course catalog. These views are: Create, Edit, and Delete. The Create view is used to add a new course to the course catalog. The Edit view is similar to the Create view except instead of adding new courses to the catalog, it allows users to update a course in the course catalog. And the Delete view is used to remove a course from the course catalog.
### Models
This project mostly consists of two models: Accounts and Courses. The Accounts model is used to contain the account information of each user. It is used in the Login, Signup, and the second Index view via sessions. The Courses model is used to contain all of the information about each course. It is used in all of the views in the Catalog controller. These two models are also used in the DbContext class "GroupProjectContext" which is found in the "Data" folder.
## Resources
Login and Signup views: https://dev.to/skipperhoa/login-and-register-using-asp-net-mvc-5-3i0g

.gitignore: https://github.com/lChap701/gitignore/blob/master/VisualStudio.gitignore
