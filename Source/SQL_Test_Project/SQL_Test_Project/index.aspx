<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SQL_Test_Project.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Custom fonts for this template-->
    <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="../css/sb-admin-2.min.css" rel="stylesheet">
</head>

<body id="page-top">

    <!-- Page Wrapper -->
    <div id="wrapper">

        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">

                <!-- Topbar -->
                <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

                    <!-- LOGO -->
                    <span style="text-align:center">
                        <img src="images/Logo.png" style="width:100px;height:80px;padding-top:20px;padding-bottom:20px" />
                    </span>

                    <!-- Topbar Navbar -->
                    <ul class="navbar-nav ml-auto">

                        <!-- Nav Item - User Information -->
                        <a class="btn btn-primary" href="aspx/signin.aspx">Sign in</a>

                    </ul>

                </nav>
                <!-- End of Topbar -->

                <!-- Begin Page Content -->
                <div>
                    <div class="container">
                        <div class="row p-5 pb-0 pe-lg-0 pt-lg-5 align-items-center rounded-3 border shadow-lg">
                            <!-- Blog entries-->
                            <div>

    <div class="card-img" style ="background-color:#56717e">
        <table class="table" width="100%" cellspacing="0">

            <tbody class="text-white">
                <tr>
                    <td>
                        <span style="font-weight:bold;font-size:16px">SQL + ASP.NET + HTML5 Framework</span><br />
                        Refference:<br />
                        <div style="font-size:14px">
                        <a class="text-white" href="https://getbootstrap.com/docs/5.0/getting-started/download/">Bootstrap 5.2.2</a><br />
                        <a class="text-white" href="https://download.visualstudio.microsoft.com/download/pr/9f4d3331-ff2a-4415-ab5d-eafc9c4f09ee/1922162c9ed35d6c10160f46c26127d6/dotnet-sdk-6.0.402-win-x64.exe">ASP.NET (dotnet-sdk-6.0.402-win-x64.exe)</a><br />
                        <a class="text-white" href="https://go.microsoft.com/fwlink/p/?linkid=866662">Microsoft SQL Server (SQL2019-SSEI-Dev.exe)</a><br />
                        
                        <a class="text-white" href="https://aka.ms/ssmsfullsetup">SQL Server Management Studio (SSMS) 18.12.1 (SSMS-Setup-ENU.exe)</a><br />
                        <a class="text-white" href="https://visualstudio.microsoft.com/vs/older-downloads/">Visual Studio Community 2019 (16.11.11)</a><br /><br />
                        
                        To get started, click on the one in the upper right corner <span style="font-weight:bold">"Sign in"</span> button.<br />
                        on the next page repeat the process (logging in details are not required).<br />
                        </div>
                    </td>
                    <td>
                        <img class="card-img" src="images/williams_f1.jpg" alt="pilt" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
                                <!-- Featured blog post-->
                                <div class="card mb-4">
                                    <div class="card-body">
                                        <div class="small text-muted">October 31, 2022</div>
                                        <h2 class="card-title">Functional requirements</h2>
                                            <div>
                                     
                                                
The web application must consist of the following views:<br/>
<span style="font-weight:bold;font-size:16px">home page</span><br/>
<span style="font-weight:bold;font-size:16px">Add event view</span><br/>
<span style="font-weight:bold;font-size:16px">The view of the participants of the event</span><br/>
<span style="font-weight:bold;font-size:16px">Add participant view</span><br/>
<span style="font-weight:bold;font-size:16px">Participant detail data viewing/editing view</span><br/>
<span style="font-weight:bold;font-size:16px">Home</span> - Contains a list of past and future events. The event name, time, place, number of participants are displayed visually. A link or button to add a participant (which leads to the form for adding a participant) and the option to delete the event for future events (deletes both the event and the participants registered for the event). In addition, it must be possible to move to the form for adding an event.<br/>
<span style="font-weight:bold;font-size:16px">Add Event View</span> - Contains a form to add new future events. You should be able to enter the following data from the form: name of the event, time of the event (you can only enter the date and time of the future), place of the event, additional information (maximum 1000 characters), add button and back button to navigate to the main page. After adding the event, automatic redirection to the home page could take place.<br/>
<span style="font-weight:bold;font-size:16px">View of persons participating in the event</span> - Clicking on the name of the event on the home page should open a view with a list of all persons participating in the event. The list should include the first and last name of each person (legal name in the case of a company), personal code (register code in the case of a company), the option to delete from the event and a back button to navigate to the home page.<br/>
<span style="font-weight:bold;font-size:16px">Participant addition view</span> - On the home page, there is a button or link behind each event to add a participant, which leads to a separate form. The form must have a choice whether to add a natural or legal person, and according to the choice made, it must be possible to enter the following data:<br/><br/>

<div class="card-body">
    <div class="table-responsive">
        <table class="table" id="dataTable" width="100%" cellspacing="0">
            <thead>
                <tr>
                    <th>Private</th>
                    <th>Enterprise</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>First name</td>
                    <td>Legal name of the company</td>
                </tr>
                <tr>
                    <td>Surname</td>
                    <td>Company registration code</td>
                </tr>
                <tr>
                    <td>Personal code</td>
                    <td>Number of participants from the company</td>
                </tr>
                <tr>
                    <td>Method of paying the participation fee (choice: bank transfer or cash)</td>
                    <td>Method of paying the participation fee (choice: bank transfer or cash)</td>
                </tr>
                <tr>
                    <td>Additional information field (maximum 1500 characters), wishes of the participant</td>
                    <td>Additional information field (maximum 5000 characters), wishes of the participant</td>
                </tr>
            </tbody>
        </table>
    </div>
</div>

                                                We make the assumption that all natural person participants have an Estonian personal identification number and its correctness is validated when entered.
Payment methods must be able to be managed without changing the source code.
The form also has a save button and a back button to navigate to the home page. After adding a participant, automatic redirection to the home page could take place.<br/>
<span style="font-weight:bold;font-size:16px">The view for viewing/changing the detailed data of the participant</span> - from the view of persons participating in the event, clicking on a person opens a view where it is possible to view and change the data saved from the form for adding a participant.<br/>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.container-fluid -->

            </div>
            <!-- End of Main Content -->

            <!-- Footer -->
            <footer class="sticky-footer bg-dark">
                <div class="container my-auto">
                    <div class="copyright text-center my-auto text-white">
                        <span>
                        Copyright &copy 2022
                        <a class="text-white" href="https://ee.linkedin.com/in/ravel-tammeleht-573860150">Ravel Tammeleht</a>.
                        </span> All rights reserved.
                    </div>
                </div>
            </footer>
            <!-- End of Footer -->

        </div>
        <!-- End of Content Wrapper -->

    </div>
    <!-- End of Page Wrapper -->

    <!-- Bootstrap core JavaScript-->
    <script src="../vendor/jquery/jquery.min.js"></script>
    <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="../js/sb-admin-2.min.js"></script>

    <!-- Page level plugins -->
    <script src="../vendor/chart.js/Chart.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="../js/demo/chart-area-demo.js"></script>
    <script src="../js/demo/chart-pie-demo.js"></script>
</body>
</html>
