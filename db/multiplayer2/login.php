<?php

require('connectionSettings.php');
require('checkcon.php');

    $username = $_POST['loginUser'];
    $password = $_POST['loginPass'];
    
    $namecheckquery = "SELECT username, salt, hash, currency FROM users WHERE username ='" . $username . "';";
    //if name occupied
    $namecheck = mysqli_query($connection, $namecheckquery) or die("2 namecheck query failed"); // error code = name query failed
    if (mysqli_num_rows($namecheck) != 1){
        echo "9 invalid user name"; // error code = too much accounts or no accounts with this name
        exit();
    }

    //get login info from query

    $existinginfo = mysqli_fetch_assoc($namecheck);
    $salt = $existinginfo["salt"];
    $hash = $existinginfo["hash"];

    $loginhash = crypt($password, $salt);
    if ($hash != $loginhash){
        echo "10: incorrect password"; // error code = pasword does not hash to match table
        exit();
    }
    echo "0\t" . $existinginfo["currency"];
?>