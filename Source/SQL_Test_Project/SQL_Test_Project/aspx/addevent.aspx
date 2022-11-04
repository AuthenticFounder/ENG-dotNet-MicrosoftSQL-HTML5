<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="SQL_Test_Project.aspx.addevent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .box{
            width:50%;
            height:300px;
            left:36%;
            top:10%;
            position:absolute;
            border-radius:20px;
        }
        .heading{
            background-color:white;
            color:gray;
            padding-left:20px;
            padding-top:10px;
            font-weight:bold;
            height:50px;
        }
        .fcol{
            width:30%;
            font-size:16px;
            font-weight:bold;
        }
        .scol{
            width:70%;
            font-size:16px;
        }
        .btnenter{
            background-color:dimgray;
            color:white;
            width:120px;
            height:40px;
            font-size:20px;
            font-weight:normal;
            border:1px solid white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="datacontent" runat="server">
            
            <!-- EVENT -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <li class="fa fa-calendar" style="font-weight:bold;font-size:20px"></li>&nbsp;&nbsp;&nbsp;&nbsp;
                    <span style="font-weight:bold;font-size:20px">Adding an event</span>
                </div>
                <div class="card-body">

                    <table class="table" style="width:100%;text-align:left">
                        <tr style="height:20px">
                            <td class="fcol" id="Td1" runat="server">
                                Event name:
                            </td>
                            <td class="scol">                                
                                <asp:TextBox ID="txtEventName" class="form-control" style="width:270px;height:34px" runat="server" placeholder="Event name" required></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="Td2" runat="server">
                                Event date:
                            </td>
                            <td class="scol">
                                <asp:TextBox ID="txtEventDate" class="form-control" style="width:270px;height:34px" runat="server" placeholder="mm/dd/yyyy" Textmode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="Td3" runat="server">
                                Location:
                            </td>
                            <td class="scol">
                                <asp:TextBox ID="txtEventLocation" class="form-control" style="width:270px;height:34px" runat="server" placeholder="Location" required></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="Td4" runat="server">
                                Additional information:
                            </td>
                            <td class="scol">
                                <asp:TextBox ID="txtEventInfo" class="form-control" style="width:270px;height:102px" runat="server" placeholder="Additional information" ></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div style="width:100%;height:70px;text-align:center;margin-top:20px">
                        <asp:Button ID="btnSessionState" runat="server" Text="Add Event" class="btn btn-primary" OnClick="btnAddEvent_Click" />
                    </div>

                </div>
            </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptcontent" runat="server">

</asp:Content>
