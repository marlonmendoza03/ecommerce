const firstName = document.getElementById('firstName');
const lastName = document.getElementById('lastName');
const email = document.getElementById('email');
const username = document.getElementById('username');
const password = document.getElementById('password');
const retypePassword = document.getElementById('retypePassword');
const steps = Array.from(document.querySelectorAll('form .step'));
const nextBtn = document.querySelectorAll('form #nextBtn');
const previousBtn = document.querySelectorAll('form #previousBtn');
const form = document.querySelector('form');

nextBtn.forEach(button => {
    button.addEventListener('click', () => {
        changeStep('next');
    })
});

previousBtn.forEach(button => {
    button.addEventListener('click', () => {
        changeStep('previous');
    })
});

function changeStep(btn) {
    let index = 0;
    const active = document.querySelector('form .step.active');
    index = steps.indexOf(active);
    steps[index].classList.remove('active');
    if (btn === 'next') {
        index++;
    } else if (btn === 'previous') {
        index--;
    }
    steps[index].classList.add('active');
};

function check_pass() {

    if (password.value == '' || retypePassword.value == '' || password.value == null || retypePassword.value == null) {
        document.getElementById('passwordWarning').innerText = 'Password Must Not Be Empty';
        document.getElementById('passwordWarning').style.display = 'block';
        document.getElementById('submitBtn').disabled = true;
    }
    if (password.value == retypePassword.value) {
        document.getElementById('passwordWarning').style.display = 'none';
        document.getElementById('submitBtn').disabled = false;
    } else {
        document.getElementById('passwordWarning').innerText = 'Password Does Not Match';
        document.getElementById('passwordWarning').style.display = 'block';
        document.getElementById('submitBtn').disabled = true;
    }
}

password.addEventListener('input', function () {
    check_pass();
});
retypePassword.addEventListener('input', function () {
    check_pass();
});

form.addEventListener('submit', (e) => {
    try {
        const inputs = [];
        form.querySelectorAll('input').forEach(input => {
            const { name, value } = input;
            inputs.push({ name, value })
        })
        console.log(inputs);

        let index = 0;
        const active = document.querySelector('form .step.active');
        index = steps.indexOf(active);
        steps[index].classList.remove('active');
        steps[0].classList.add('active');

        if (firstName.value == null || lastName.value == null || username.value == null || email.value == null || password.value == null || retypePassword.value == null) {
            alert('Please fill in the required fields');
        } else {
            if (password.value == retypePassword.value) {
                alert('Success! Please Login!');
            } else {
                alert('Password does not match!');
            }
        }
    }
    catch (e) {
        console.log(e);
    }
});