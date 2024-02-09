<?php
setcookie("super_secret_token", "123456789");
?>

<html>

<head>
</head>

<body>
    <?php

    print "Information: " . urldecode($_SERVER["REQUEST_URI"]);
    //print "Information: " . htmlspecialchars(urldecode(($_SERVER["REQUEST_URI"])), ENT_QUOTES, "UTF-8");
    ?>

    <!-- <script>
        var token = document.cookie;
        alert("Token: " + token);
    </script> -->

</body>

</html>