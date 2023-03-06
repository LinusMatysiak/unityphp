<?php

    require('checkcon.php');
    require('connectionSettings.php');

    $username = $_POST["loginUser"];
    $password = $_POST["loginPass"];
    $email = $_POST["loginEmail"];

    $namecheckquery = "SELECT username FROM users WHERE username ='" . $username . "';";
    $emailcheckquery = "SELECT email FROM users WHERE email ='" . $email . "';";
    //if name occupied
    $namecheck = mysqli_query($connection, $namecheckquery) or die("2 namecheck query failed"); // error code = name query failed
    $emailcheck = mysqli_query($connection, $emailcheckquery) or die("3 emailcheck query failed"); // error code = name query failed

    if (mysqli_num_rows($namecheck) > 0){
        echo "4 userame already exists"; // error code = name occupied
        exit();
    }

    if (mysqli_num_rows($emailcheck) > 0){
        echo "5 email in use"; // error code = name occupied
        exit();
    }


    //adding user

    $salt = "\$5\$rounds=2000\$" . "phppassencrypt" . $username . "\$";
    $hash = crypt($password, $salt);
    if(strlen($username) < 5 ){
        echo "6 too short username";
        exit();
    } else{
        if(strlen(($email) < 5)){
            echo "7 enter real email";
            exit();
        }
        else{
            $insertuserquery = "INSERT INTO users (username, hash, salt, email) VALUES ('" . $username ."', '" . $hash . "', '" . $salt . "', '" . $email . "');";
            mysqli_query($connection, $insertuserquery) or die("8 query failed"); // error code = insert query failed
        }
    }
    echo ("0");
?>