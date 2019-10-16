function Test() {
    console.log('This is test method');
}

Test();

$(document).ready(function () {

    $('account-menu').mouseenter(() => alert('mixi'));

    $('account-menu').hover(() => alert('dabba'), () => $(this).removeClass('open'));
});