var logButton = document.getElementById('loginBtn');
var signButton = document.getElementById('signBtn');
var parent = document.querySelector('.login-popup__content');
logButton.addEventListener("click", function() {
  if (!(logButton.classList.contains('button--active'))) {
    logButton.classList.add('button--active');
    signButton.classList.remove('button--active');
    parent.innerHTML = "<div class='login-popup__row'><label for='login' class='login-popup__text' for='login' >Логин</label><input id='login' name = 'login' type = 'text' class = 'input' ></div><div class='login-popup__row login-popup__row--last'><label for='password' class='login-popup__text'>Пароль</label><input id='password' name='password' type='text' class='input'></div><button class='button button--big'>Вход</button>";
  }
});
signButton.addEventListener("click", function() {
  if (!(signButton.classList.contains('button--active'))) {
    signButton.classList.add('button--active');
    logButton.classList.remove('button--active');
    parent.innerHTML = "<div class='login-popup__row'><label for='signlogin' class='login-popup__text' for='login'>Логин</label><input id='signlogin' name='signlogin' type ='text' class='input'></div><div class='login-popup__row'><label for='signpassword' class='login-popup__text'>Пароль</label><input id='signpassword' name='signpassword' type='text' class='input'></div><div class='login-popup__row'><label for='mail' class='login-popup__text'>Почта</label><input id='mail' name='mail' type='text' class='input'></div><div class='login-popup__row'><label for='univ' class='login-popup__text'>Вуз</label><input id='univ' name='univ' type='text' class='input'></div><div class='login-popup__row login-popup__row--last'><label for='facult' class='login-popup__text'>Факультет</label><input id='facult' name='facult' type='text' class='input'></div><button class='button button--big'>Регистрация</button>";
  }
});
var event = new Event("click");
logButton.dispatchEvent(event);
