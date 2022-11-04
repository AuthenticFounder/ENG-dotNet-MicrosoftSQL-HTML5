<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="SQL_Test_Project.aspx.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">        
        .fcol{
            width:30%;
            font-size:16px;
            font-weight:bold;
        }
        .scol{
            width:70%;
            font-size:16px;
        }
        .btnadd{
            width:200px;
            height:40px;
            font-size:16px;
            font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="datacontent" runat="server">


                <!-- Begin Page Content -->
                <div class="container-fluid">

                    <!-- Page Heading -->

                    <!-- Content Row -->
                    <div class="row">

                        <div class="col-xl-6 col-lg-5">

                            <!-- T1 -->
                            <div class="card shadow mb-4">
                                <div class="card-header py-3">
                                    <h6 class="m-0 font-weight-bold text-primary"><i class="fas fa-fw fa-eye"></i>Upcoming events</h6>
                                </div>
                                <div class="card-body">
                                    <div class="table-responsive"> 
                                        <asp:Panel ID="Panel1" runat="server" DefaultButton="ImageButtonSubmit">
                                            <asp:GridView ID="GridView1" runat="server" PageSize="10" AutoGenerateColumns="false" AllowPaging="true" BackColor="White" BorderColor="#ffffff" BorderStyle="None" BorderWidth="0px" CellPadding="2" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">  
                
                                                <FooterStyle BackColor="#ffffff" ForeColor="#515151" />  
                                                <RowStyle BackColor="White" ForeColor="#a4a4a4" />  
                                                <SelectedRowStyle BackColor="#e7ca90" Font-Bold="True" ForeColor="#224960" />  
                                                <PagerStyle BackColor="#ffffff" ForeColor="#569900" HorizontalAlign="Center" />  
                                                <HeaderStyle BackColor="#56717e" Font-Bold="True" ForeColor="#eef2f5" />  
                                                <Columns >  
                                                    <asp:TemplateField HeaderText="ID" >  
                                                        <ItemTemplate>  
                                                            <asp:Label style="width:70px;height:34px" ID="lbleid" runat="server" Text='<%#Eval ("eID")%>'></asp:Label>  
                                                        </ItemTemplate>  
                                                    </asp:TemplateField>  
                                                    <asp:TemplateField HeaderText="NUM">  
                                                        <ItemTemplate>                              
                                                            <asp:TextBox class="form-control" style="width:60px;height:34px" ID="txtpcnt" runat="server" Text='<%#Eval("pCNT")%>'> </asp:TextBox>  
                                                        </ItemTemplate>  
                                                    </asp:TemplateField> 
                                                    <asp:TemplateField HeaderText="Event Name">  
                                                        <ItemTemplate>  
                                                            <asp:TextBox class="form-control" style="width:150px;height:34px" ID="txteventname" runat="server" Text='<%#Eval("EventName")%>'> </asp:TextBox>   
                                                        </ItemTemplate>  
                                                    </asp:TemplateField> 
                                                    <asp:TemplateField HeaderText="Date">  
                                                        <ItemTemplate>  
                                                            <asp:TextBox class="form-control" style="width:120px;height:34px" ID="txteventdate" runat="server" Text='<%#Eval("EventDate")%>'> </asp:TextBox>    
                                                        </ItemTemplate>  
                                                    </asp:TemplateField> 
                                                    <asp:TemplateField HeaderText="Location">  
                                                        <ItemTemplate>  
                                                            <asp:TextBox class="form-control" style="width:100px;height:34px" ID="txteventlocation" runat="server" Text='<%#Eval("EventLocation")%>'> </asp:TextBox> 
                                                        </ItemTemplate>  
                                                    </asp:TemplateField>  
                                                    <asp:TemplateField HeaderText="Edit" ShowHeader="false">  
                                                        <EditItemTemplate>  
                                                            <asp:LinkButton Width="80" ID="lnkbtnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>  
                                                            <asp:LinkButton Width="80" ID="lnkbtnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>  
                                                        </EditItemTemplate> 
                                                        <ItemTemplate>  
                                                            <asp:LinkButton Width="80" ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit"></asp:LinkButton>  
                                                        </ItemTemplate> 
                                                    </asp:TemplateField>
                    
                                                    <asp:TemplateField HeaderText="Attenders" ShowHeader="false">  
                                                        <ItemTemplate>  
                                                            <asp:LinkButton ID="btnOsavotjad" runat="server" CausesValidation="false" CommandName="cmdAddParticipant" Text="Attenders"></asp:LinkButton>  
                                                        </ItemTemplate> 
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="" ShowHeader="false">  
                                                        <ItemTemplate>  
                                                            <asp:ImageButton ID="ibtnRemove" runat="server" style="width:10px;height:10px" ImageUrl="~/images/delete-button.svg" CausesValidation="false" CommandName="Delete" />
                                                        </ItemTemplate> 
                                                    </asp:TemplateField> 
                                                </Columns>  
                                            </asp:GridView>
                                            <!-- Return key hack... -->
                                            <asp:ImageButton style="width:0px;height:0px" ID="ImageButtonSubmit" runat="server" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                          
                            <div style="width:100%;height:70px;text-align:left;margin-top:20px">
                                <asp:Button ID="btnadd" runat="server" Text="Add an event" class="btn btn-primary" OnClick="btnAddEvent_Click"/>
                            </div>
                        </div>

                        <div class="col-xl-6 col-lg-5">

                            <!-- T2 -->
                            <div class="card shadow mb-4">
                                <div class="card-header py-3">
                                    <h6 class="m-0 font-weight-bold text-primary"><i class="fas fa-fw fa-briefcase"></i>Held events</h6>
                                </div>
                                <div class="card-body">
                                    <div class="table-responsive">
                                         <asp:GridView ID="GridView2" runat="server" PageSize="10" AutoGenerateColumns="false" AllowPaging="true" BackColor="White" BorderColor="#ffffff" BorderStyle="None" BorderWidth="0px" CellPadding="2" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnRowCommand="GridView2_RowCommand" >  
                                                                         
                                            <FooterStyle BackColor="#ffffff" ForeColor="#515151" />  
                                            <RowStyle BackColor="White" ForeColor="#a4a4a4" />  
                                            <SelectedRowStyle BackColor="#e7ca90" Font-Bold="True" ForeColor="#224960" />  
                                            <PagerStyle BackColor="#ffffff" ForeColor="#569900" HorizontalAlign="Center" />  
                                            <HeaderStyle BackColor="#56717e" Font-Bold="True" ForeColor="#eef2f5" />  
                                            <Columns>  
                                                <asp:TemplateField HeaderText="ID" >  
                                                    <ItemTemplate>  
                                                        <asp:Label style="width:40px;height:34px"  ID="lbleid" runat="server" Text='<%#Eval ("eID")%>'></asp:Label>  
                                                    </ItemTemplate>  
                                                </asp:TemplateField>  
                                                <asp:TemplateField HeaderText="NUM">  
                                                    <ItemTemplate>                              
                                                        <asp:Label style="width:30px;height:34px"  ID="lblpcnt" runat="server" Text='<%#Eval("pCNT")%>'> </asp:Label>  
                                                    </ItemTemplate>  
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Event Name">  
                                                    <ItemTemplate>  
                                                        <asp:Label style="width:270px;height:34px"  ID="lbleventname" runat="server" Text='<%#Eval("EventName")%>'> </asp:Label>   
                                                    </ItemTemplate>  
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Date">  
                                                    <ItemTemplate>  
                                                        <asp:Label style="width:100px;height:34px"  ID="lbleventdate" runat="server" Text='<%#Eval("EventDate")%>'> </asp:Label>    
                                                    </ItemTemplate>  
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Location">  
                                                    <ItemTemplate>  
                                                        <asp:Label style="width:120px;height:34px"  ID="lbleventlocation" runat="server" Text='<%#Eval("EventLocation")%>'> </asp:Label> 
                                                    </ItemTemplate>  
                                                </asp:TemplateField>  
                                        
                                                <asp:TemplateField HeaderText="Attenders" ShowHeader="false">  
                                                    <ItemTemplate>  
                                                        <asp:LinkButton ID="btnOsavotjad" runat="server" CausesValidation="false" CommandName="cmdAddParticipant" Text="Attenders"></asp:LinkButton>  
                                                    </ItemTemplate> 
                                                </asp:TemplateField>
                                            </Columns>  
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
                <!-- /.container-fluid -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptcontent" runat="server">
</asp:Content>
