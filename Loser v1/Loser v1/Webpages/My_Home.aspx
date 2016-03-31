<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My_Home.aspx.cs" Inherits="Loser_v1.Webpages.My_Home" %>

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

     <!-- BEGIN LOGIN -->
     <div class="content">

          <!-- BEGIN LOGIN FORM -->
          <form runat="server" class="form-vertical login-form">
               <h3 class="form-title">Login to your account</h3>

               <div class="alert alert-error hide">
                    <button class="close" data-dismiss="alert"></button>
                    <span>Enter any Soulname and Password.</span>
               </div>

               <div class="control-group">
                    <label class="control-label visible-ie8 visible-ie9">Soulname</label>
                    <div class="controls">
                         <div class="input-icon left">
                              <i class="icon-user"></i>
                              <asp:TextBox ID="tb_soulname" runat="server" class="m-wrap placeholder-no-fix" placeholder="Soulname"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rfv_soulname" runat="server" ErrorMessage="Enter Your Soul Name" ControlToValidate="tb_soulname" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                         </div>
                    </div>
               </div>

               <div class="control-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                    <div class="controls">
                         <div class="input-icon left">
                              <i class="icon-lock"></i>
                              <asp:TextBox ID="tb_password" runat="server" class="m-wrap placeholder-no-fix" placeholder="Password" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rfv_password" runat="server" ErrorMessage="Enter Your Password" ControlToValidate="tb_password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                         </div>
                    </div>
               </div>

               <div class="form-actions">
                    <label class="checkbox">
                         <input type="checkbox" name="remember" value="1" />
                         Remember me
                    </label>

                    <asp:Button ID="btn_login" CssClass="btn blue pull-right" runat="server" OnClick="btn_login_Click" Text="Login" />
               </div>

               <div class="forget-password">
                    <h4>Forgot your password ?</h4>
                    <p>
                         Just click <a href="javascript:;" id="forget-password"><b>here</b></a>
                         to reset your password.
                    </p>
               </div>

               <div class="create-account">
                    <p>
                         Don't have an account yet ?&nbsp; &nbsp; 
					<a href="My_Register.aspx"><b>Create an account</b></a>
                    </p>
               </div>
          </form>
          <!-- END LOGIN FORM -->
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
     <!-- END JAVASCRIPTS -->
</body>
</html>
