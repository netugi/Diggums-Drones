<?php

$con = mysqli_connect('localhost', 'root', 'root', 'DiggumsAccess');

    //check the connection happen
    if(mysqli_connect_errno()){
        echo "connection failed"; 
        exit();
    }

    $username = $_POST["name"];
    $loginpassword = $_POST["password"];

    $namecheckquery = "SELECT UserName, password, Maxlvl FROM players WHERE UserName = '" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("name check query failed"); 

    if(mysqli_num_rows($namecheck) != 1){
        echo "5: no user with name";
        exit();
    }

    // get login info from query

    $existinginfo = mysqli_fetch_assoc($namecheck);
    $password = $existinginfo["password"];

    if($loginpassword != $password ){
        echo "6: password is incorrect";
        exit();
    }

    echo "0\t" . $existinginfo["Maxlvl"];




?>