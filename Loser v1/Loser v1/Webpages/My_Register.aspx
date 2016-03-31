<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My_Register.aspx.cs" Inherits="Loser_v1.Webpages.My_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
     <title>Login Form</title>
     <meta content="width=device-width, initial-scale=1.0" name="viewport" />
     <meta content="" name="description" />
     <meta content="" name="author" />
     <!-- BEGIN GLOBAL MANDATORY STYLES -->
     <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
     <link href="assets/plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
     <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
     <link href="assets/css/style-metro.css" rel="stylesheet" type="text/css" />
     <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
     <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
     <link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
     <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2_metro.css" />
     <!-- END GLOBAL MANDATORY STYLES -->
     <!-- BEGIN PAGE LEVEL STYLES -->
     <link href="assets/css/pages/login-soft.css" rel="stylesheet" type="text/css" />
     <!-- END PAGE LEVEL STYLES -->
     <link rel="shortcut icon" href="favicon.ico" />
</head>

<body class="login">

     <!-- BEGIN LOGO -->
     <div class="logo">
          <!-- PUT YOUR LOGO HERE -->
     </div>
     <!-- END LOGO -->

     <div class="content">

          <form id="form1" class="form-vertical login-form" runat="server">

               <!-- BEGIN REGISTRATION FORM -->

               <h3>Sign Up</h3>

               <p>Enter your account details below:</p>

               <div class="control-group">

                    <label class="control-label visible-ie8 visible-ie9">Email</label>
                    <div class="controls">
                         <div class="input-icon left">
                              <i class="icon-envelope"></i>
                              <asp:TextBox ID="tb_email" placeholder="Email" runat="server" CssClass="m-wrap placeholder-no-fix"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rf_email" runat="server" ErrorMessage="Enter Email Address" ControlToValidate="tb_email" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="re_email" runat="server" ErrorMessage="Enter Valid Email Address" ControlToValidate="tb_email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                         </div>
                    </div>
               </div>

               <div class="control-group">
                    <label class="control-label visible-ie8 visible-ie9">Soulname</label>
                    <div class="controls">
                         <div class="input-icon left">
                              <i class="icon-user"></i>
                              <asp:TextBox ID="tb_username" placeholder="Soulname" runat="server" CssClass="m-wrap placeholder-no-fix"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rf_username" runat="server" ErrorMessage="Enter Soul Name" ControlToValidate="tb_username" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                    </div>
               </div>

               <div class="control-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                    <div class="controls">
                         <div class="input-icon left">
                              <i class="icon-lock"></i>
                              <asp:TextBox ID="tb_password" placeholder="Password" TextMode="Password" runat="server" CssClass="m-wrap placeholder-no-fix"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rf_password" runat="server" ErrorMessage="Enter Password" ControlToValidate="tb_password" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                    </div>
               </div>

               <div class="control-group">
                    <label class="control-label visible-ie8 visible-ie9">Re-type Your Password</label>
                    <div class="controls">
                         <div class="input-icon left">
                              <i class="icon-ok"></i>
                              <asp:TextBox ID="tb_again" placeholder="Re-type Your Password" TextMode="Password" runat="server" CssClass="m-wrap placeholder-no-fix"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rf_again" runat="server" ErrorMessage="Re-Enter Password" ControlToValidate="tb_again" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                              <asp:CompareValidator ID="cv_password" runat="server" ErrorMessage="Password do not match" ControlToCompare="tb_password" ControlToValidate="tb_again" ForeColor="Red"></asp:CompareValidator>
                         </div>
                    </div>
               </div>

               <label class="checkbox">
                    <asp:CheckBox ID="chk_terms" runat="server" />
                    I agree to the <a href="#">Terms of Service</a> and <a href="#">Privacy Policy</a>
               </label>
               
               <asp:Label ID="lb_msg" runat="server" Visible="false" ForeColor="Red" Text="Please Accept our Terms & Policy for Registration"></asp:Label>
               
               <div class="form-actions">

                    <asp:Button ID="btn_back" CssClass="btn" runat="server" Text="Back" CausesValidation="false" OnClick="btn_back_Click" />

                    <asp:Button ID="btn_signup" CssClass="btn green pull-right" runat="server" Text="Sign Up" CausesValidation="true" OnClick="btn_signup_Click" />

                    <%--<button id="register-back-btn" type="button" class="btn">
                         <i class="m-icon-swapleft"></i>Back
                    </button>--%>

                    <%--<button type="submit" id="register-submit-btn" class="btn green pull-right">
                         Sign Up <i class="m-icon-swapright m-icon-white"></i>
                    </button>--%>
               </div>
          </form>
          <!-- END REGISTRATION FORM -->
     </div>

     <!-- BEGIN COPYRIGHT -->
     <div class="copyright">
          2015 &copy; <a href="http://www.loser.com/">Loser.com</a>
     </div>
     <!-- END COPYRIGHT -->

     <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
     <!-- BEGIN CORE PLUGINS -->
     <script src="assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
     <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
     <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
     <script src="assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
     <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
     <script src="assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
     <!--[if lt IE 9]>
	<script src="assets/plugins/excanvas.min.js"></script>
	<script src="assets/plugins/respond.min.js"></script>  
	<![endif]-->
     <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
     <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
     <script src="assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>
     <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
     <!-- END CORE PLUGINS -->
     <!-- BEGIN PAGE LEVEL PLUGINS -->
     <script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js" type="text/javascript"></script>
     <script src="assets/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
     <script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>
     <!-- END PAGE LEVEL PLUGINS -->
     <!-- BEGIN PAGE LEVEL SCRIPTS -->
     <script src="assets/scripts/app.js" type="text/javascript"></script>
     <script src="assets/scripts/login-soft.js" type="text/javascript"></script>
     <!-- END PAGE LEVEL SCRIPTS -->
     <script>
          jQuery(document).ready(function () {
               App.init();
               Login.init();
          });
     </script>

</body>
</html>
