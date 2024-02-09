<?php
$label = '';
$count = 0;

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $count = $_POST['count'];
    $count++;
    $label = "You pressed the button $count times";
}
?>

<!DOCTYPE html>
<html>
<body>

<form method="post" action="<?php echo $_SERVER['PHP_SELF'];?>">
    <label><?php echo $label;?></label>
    <input type="submit" value="Press me">
</form>

</body>
</html>