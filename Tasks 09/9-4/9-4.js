var counter;
function startTimer_1() {
    var my_timer = document.getElementById("my_timer");
    var stop_button = document.getElementById("button_stop");
    var time = my_timer.innerHTML;
    var arr = time.split(":");
    var h = arr[0];
    var m = arr[1];
    var s = arr[2];
    if (s == 0) {
      if (m == 0) {
        if (h == 0) {
            document.location.href = "9-4-2.html";
          return;
        }
        h--;
        m = 60;
        if (h < 10) h = "0" + h;
      }
      m--;
      if (m < 10) m = "0" + m;
      s = 59;
    }
    else s--;
    if (s < 10) s = "0" + s;
    document.getElementById("my_timer").innerHTML = h+":"+m+":"+s;
    counter = setTimeout(startTimer_1, 1000);
  }
  function startTimer_2() {
    var my_timer = document.getElementById("my_timer");
    var stop_button = document.getElementById("button_stop");
    var time = my_timer.innerHTML;
    var arr = time.split(":");
    var h = arr[0];
    var m = arr[1];
    var s = arr[2];
    if (s == 0) {
      if (m == 0) {
        if (h == 0) {
            /*window.open("9-4-3.html","9-4-3");*/
           document.location.href = "9-4-3.html";
          return;
        }
        h--;
        m = 60;
        if (h < 10) h = "0" + h;
      }
      m--;
      if (m < 10) m = "0" + m;
      s = 59;
    }
    else s--;
    if (s < 10) s = "0" + s;
    document.getElementById("my_timer").innerHTML = h+":"+m+":"+s;
    counter = setTimeout(startTimer_2, 1000);
  }
  function startTimer_3() {
    var my_timer = document.getElementById("my_timer");
    var stop_button = document.getElementById("button_stop");
    var time = my_timer.innerHTML;
    var arr = time.split(":");
    var h = arr[0];
    var m = arr[1];
    var s = arr[2];
    if (s == 0) {
      if (m == 0) {
        if (h == 0) {
            exit();
        }
        h--;
        m = 60;
        if (h < 10) h = "0" + h;
      }
      m--;
      if (m < 10) m = "0" + m;
      s = 59;
    }
    else s--;
    if (s < 10) s = "0" + s;
    document.getElementById("my_timer").innerHTML = h+":"+m+":"+s;
    counter = setTimeout(startTimer_3, 1000);
  }



function stop_1(){
    clearTimeout(counter);
}
function continue_1(){
    clearTimeout(counter);
    startTimer_1();
}
function reset_1(){
    var old_value = document.getElementById('my_timer');
    clearTimeout(counter);
    old_value.innerHTML = "00:00:5";
    startTimer_1();
}


function stop_2(){
    clearTimeout(counter);
}
function back_2(){
  document.location.href = "9-4.html";
}
function continue_2(){
    clearTimeout(counter);
    startTimer_2();
}
function reset_2(){
    var old_value = document.getElementById('my_timer');
    clearTimeout(counter);
    old_value.innerHTML = "00:00:4";
    startTimer_2();
}


function stop_3(){
    clearTimeout(counter);
}
function back_3(){
  document.location.href = "9-4-2.html";
}
function continue_3(){
    clearTimeout(counter);
    startTimer_3();
}
function reset_3(){
    var old_value = document.getElementById('my_timer');
    clearTimeout(counter);
    old_value.innerHTML = "00:00:3";
    startTimer_3();
}

function exit(){
    var thisWindow = window.open("9-4-3.html",'_self');
    var exit = confirm("Restart?");
    if(exit){
    document.location.href = "9-4.html"
}
    else{
    thisWindow.close();
}
}