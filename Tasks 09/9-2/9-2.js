function match(){
  var str
  str = document.getElementById('input').value
  var op_result = str.match(/(\+)|(\*)|(\-)|(\/)|(\=)/g)
  var num_result = str.match(/([0-9][\.\d]*)/g)
  for(var i = 0; i<num_result.length;i++)
  {
    num_result[i] = +num_result[i]
  }
    var result = num_result[0]
  console.log(result)
  for(var i = 0; i < op_result.length;i++)
  {
    switch(op_result[i])
    {
      case '+':
      result = result + num_result[i+1]
      break;
      case '-':
      result = result - num_result[i+1]
      break;
      case '*':
      result = result * num_result[i+1]
      break;
      case '/':
      result = result / num_result[i+1]
      break;
      case '=':
      /*econsole.log(result.toFixed(2))*/
      (alert(result.toFixed(2)))
      break;
    }
  }
}