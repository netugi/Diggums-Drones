<?php
    
    $con = mysqli_connect('localhost', 'root', 'root', 'DiggumsAccess');

    //check the connection happen
    if(mysqli_connect_errno()){
        echo "comnection failed"; 
        exit();
    }

    $username = $_POST["name"];
    $password = $_POST["password"];

    //check if name exist

    $namecheckquery = "SELECT UserName FROM players WHERE UserName = '" . $username . "';";

    $namecheck = mysqli_connect($con, $namecheckquery) or die("name check query failed"); 
    

    if(mysqli_num_rows($namecheck) > 0){
        echo "Name already exist";
        exit();
    }

    //add user to the table

    $salt = "\$5\$rounds=5000\$" . "pussycatdol" . $username . "\$"; //security?
    $hash = crypt($password, $salt);
    $insertuserquery = "INSERT INTO players (UserName, hash, salt) VALUES ('" . $username  . "', '" . $hash . "', '" . $salt . "');"; 
    mysqli_query($con, $insertuserquery) or die("insert query failure");

    echo("0");

?>