var sel_1 = document.getElementById('sel_1')
var sel_2 = document.getElementById('sel_2')
var sel_3 = document.getElementById('sel_3')
var sel_4 = document.getElementById('sel_4')

function moveall_right_1(){
  var options = sel_1.innerHTML
  var options = sel_2.innerHTML + options
  sel_2.innerHTML=options
  sel_1.innerHTML = null
}
function moveall_left_1(){
  var options = sel_2.innerHTML
  var options = sel_1.innerHTML + options
  sel_1.innerHTML=options
  sel_2.innerHTML = null
}
function move_right_1(){
    if(sel_1.options[sel_1.selectedIndex] == null){
        alert('You must select at least one item.')
    }
    else{
        var options = sel_1.options[sel_1.selectedIndex].innerHTML
        var new_obj = document.createElement('option')
        new_obj.innerHTML = options
        sel_2.appendChild(new_obj)
        sel_1.removeChild(sel_1.options[sel_1.selectedIndex])
    } 
}
function move_left_1(){
    if(sel_2.options[sel_2.selectedIndex] == null){
        alert('You must select at least one item.')
    }
    else{
        var options = sel_2.options[sel_2.selectedIndex].innerHTML
        var new_obj = document.createElement('option')
        new_obj.innerHTML = options
        sel_1.appendChild(new_obj)
        sel_2.removeChild(sel_2.options[sel_2.selectedIndex])
    }
}

function moveall_right_2(){
    var options = sel_3.innerHTML
    var options = sel_4.innerHTML + options
    sel_4.innerHTML=options
    sel_3.innerHTML = null
  }
  function moveall_left_2(){
    var options = sel_4.innerHTML
    var options = sel_3.innerHTML + options
    sel_3.innerHTML=options
    sel_4.innerHTML = null
  }
  function move_right_2(){
      if(sel_3.options[sel_3.selectedIndex] == null){
          alert('You must select at least one item.')
      }
      else{
          var options = sel_3.options[sel_3.selectedIndex].innerHTML
          var new_obj = document.createElement('option')
          new_obj.innerHTML = options
          sel_4.appendChild(new_obj)
          sel_3.removeChild(sel_3.options[sel_3.selectedIndex])
      } 
  }
  function move_left_2(){
      if(sel_4.options[sel_4.selectedIndex] == null){
          alert('You must select at least one item.')
      }
      else{
          var options = sel_4.options[sel_4.selectedIndex].innerHTML
          var new_obj = document.createElement('option')
          new_obj.innerHTML = options
          sel_3.appendChild(new_obj)
          sel_4.removeChild(sel_4.options[sel_4.selectedIndex])
      }
  }