<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addparticipant.aspx.cs" Inherits="SQL_Test_Project.participants.addparticipant" %>
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
    <script type="text/javascript">
    function ShowPopup() {
        $("#participantModal").modal("show");
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="datacontent" runat="server">


            <!-- Attendee -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <li class="fa fa-users" style="font-weight:bold;font-size:20px"></li>&nbsp;&nbsp;&nbsp;&nbsp;
                    <span style="font-weight:bold;font-size:20px">Attenders</span>
                </div>
                <div class="card-body">
                    
                    <table class="table" style="width:100%;text-align:left">
                        <tr style="height:20px">
                            <td class="fcol" id="Td5" runat="server">
                                Event Name:
                            </td>
                            <td class="scol">                                
                                <asp:Label ID="lblEventName" runat="server" Text="----"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="Td6" runat="server">
                                Event date:
                            </td>
                            <td class="scol">
                                <asp:Label ID="lblEventDate" runat="server" Text="----"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="Td7" runat="server">
                                Location:
                            </td>
                            <td class="scol">
                                <asp:Label ID="lblEventLocation" runat="server" Text="----"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="Td8" runat="server">
                                Attenders:
                            </td>
                            <td class="scol">
                                <asp:GridView ID="GridView3" runat="server" PageSize="10" AutoGenerateColumns="false" AllowPaging="true" BackColor="White" BorderColor="#ffffff" BorderStyle="None" BorderWidth="0px" CellPadding="2" OnRowUpdating="GridView3_RowUpdating" OnRowDeleting="GridView3_RowDeleting" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowDataBound="GridView3_RowDataBound" OnRowCommand="GridView3_RowCommand">

                                    <FooterStyle BackColor="#ffffff" ForeColor="#515151" />  
                                    <RowStyle BackColor="White" ForeColor="#a4a4a4" />  
                                    <SelectedRowStyle BackColor="#e7ca90" Font-Bold="True" ForeColor="#224960" />  
                                    <PagerStyle BackColor="#ffffff" ForeColor="#569900" HorizontalAlign="Center" />  
                                    <HeaderStyle BackColor="#56717e" Font-Bold="True" ForeColor="#eef2f5" />  
                                    <Columns >  
                                        <asp:TemplateField HeaderText="ID" >  
                                            <ItemTemplate>  
                                                <asp:Label style="width:70px;height:34px" ID="lblpid" runat="server" Text='<%#Eval ("ID")%>'></asp:Label>  
                                            </ItemTemplate>  
                                        </asp:TemplateField>  
                                        <asp:TemplateField HeaderText="First name">  
                                            <ItemTemplate>  
                                                <asp:Label style="width:150px;height:34px" ID="lblParticipantFirstname" runat="server" Text='<%#Eval("FirstName")%>'> </asp:Label>   
                                            </ItemTemplate>  
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="Surname">  
                                            <ItemTemplate>  
                                                <asp:Label style="width:100px;height:34px" ID="lblParticipantLastname" runat="server" Text='<%#Eval("LastName")%>'> </asp:Label> 
                                            </ItemTemplate>  
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="Personal code">  
                                            <ItemTemplate>  
                                                <asp:Label style="width:100px;height:34px" ID="lblParticipantIdcode" runat="server" Text='<%#Eval("Code")%>'> </asp:Label> 
                                            </ItemTemplate>  
                                        </asp:TemplateField> 
                    
                                        <asp:TemplateField HeaderText="VIEW" ShowHeader="false">  
                                            <ItemTemplate>  
                                                <asp:LinkButton ID="btnVaata" runat="server" CausesValidation="false" CommandName="cmdViewParticipant" Text="VIEW"></asp:LinkButton>  
                                            </ItemTemplate> 
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="DELETE" ShowHeader="false">  
                                            <ItemTemplate>  
                                                <asp:LinkButton ID="btnRemove" runat="server" CausesValidation="false" CommandName="Delete" Text="DELETE"></asp:LinkButton>  
                                            </ItemTemplate> 
                                        </asp:TemplateField> 
                                    </Columns> 
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <!-- Attender -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <li class="fa fa-user" style="font-weight:bold;font-size:20px"></li>&nbsp;&nbsp;&nbsp;&nbsp;
                    <span style="font-weight:bold;font-size:20px">Attender</span>
                </div>
                <div class="card-body">

                    <table class="table" style="width:100%;text-align:left">
                        <tr style="height:20px">
                            <td class="fcol"></td>
                            <td class="scol">
                                <asp:RadioButton ID="rbtnParticipant" runat="server" GroupName="participantType" Text="Private" AutoPostBack="true" OnCheckedChanged="rbtn_CheckedChanged" />
                                <asp:RadioButton ID="rbtnCompany" runat="server" GroupName="participantType" Text="Enterprise" AutoPostBack="true" OnCheckedChanged="rbtn_CheckedChanged" />      
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="lblFName" runat="server">
                                First name:
                            </td>
                            <td class="scol">
                                <asp:TextBox ID="txtParticipantFirstName" class="form-control" style="width:270px;height:34px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="lblLName" runat="server">
                                Surname:
                            </td>
                            <td class="scol">
                                <asp:TextBox ID="txtParticipantLastName" class="form-control" style="width:270px;height:34px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="lblIDCODE" runat="server">
                                Personal code:
                            </td>
                            <td class="scol">
                                <asp:TextBox ID="txtParticipantIdcode" class="form-control" style="width:270px;height:34px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="lblPayment" runat="server">
                                Payment method:
                            </td>
                            <td class="scol">
                                <asp:DropDownList ID="paymentType" CssClass="form-control" runat="server" AutoPostBack="true" style="width:270px;height:34px">
                                    <asp:ListItem>Cash</asp:ListItem>
                                    <asp:ListItem>With a card</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td class="fcol" id="lblInfo" runat="server">
                                Additional information:
                            </td>
                            <td class="scol">                                
                                <asp:TextBox ID="txtParticipantInfo" class="form-control" style="width:270px;height:102px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    
                    <div style="width:100%;height:70px;text-align:center;margin-top:20px">
                        <asp:Button ID="btnAddParticipant" runat="server" Text="Add" class="btn btn-primary" OnClick="btnAddParticipant_Click" />
                    </div>

                </div>
            </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptcontent" runat="server">
</asp:Content>
