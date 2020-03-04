<?php
    
    $con = mysqli_connect('localhost', 'root', 'root', 'DiggumsAccess');

    //check the connection happen
    if(mysqli_connect_errno()){
        echo "1:connection failed"; 
        exit();
    }

    $username = $_POST["name"];
    $password = $_POST["password"];

    //check if name exist

    $namecheckquery = "SELECT UserName FROM players WHERE UserName = '" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("2:name check query failed"); 
    

    if(mysqli_num_rows($namecheck) > 0){
        echo "3:Name already exist";
        exit();
    }

    //add user to the table

    $insertuserquery = "INSERT INTO players (UserName, password) VALUES( '" . $username . "' , '" . $password . "');"; 
    mysqli_query($con, $insertuserquery) or die("4:insert query failure");

    echo ("0");

?>