/* LOG */
console.log('Start of MyScript.js')

/* URL REDIRECT */
/* Redirect url when the path name is empty */
if (window.location.href == "https://localhost:7054/") {
    window.location.href = 'https://localhost:7054/Forum/Container';
}

/* TOOLTIPS */
const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));


/* EDIT FUNCTION */
var edit = function(btn_id) {
    console.log(`Clicked on editBtn-${btn_id}`);

    // Getting the elements we are going to need
    var editBtn = document.getElementById(`editBtn-${btn_id}`);
    $(editBtn).addClass('disabled');

    var commentBody = document.getElementById(`comment-${btn_id}-body`);
    var originalContent = commentBody.innerHTML;

    var saveBtn = document.getElementById(`save-comment-${btn_id}`);
    var cancelBtn = document.getElementById(`cancel-save-${btn_id}`);

    var input = document.getElementById(`comment-${btn_id}-input`);

    // Slow fade
    $(saveBtn).fadeToggle('slow');
    $(cancelBtn).fadeToggle('slow');

    // Prevent from losing focus when clicking outside any relevant elements
    document.addEventListener('mousedown', function preventBlur(event) {
        var hasFocus = (document.activeElement === commentBody);

        if (event.target != saveBtn
            && event.target != cancelBtn
            && event.target != commentBody
            && hasFocus) {
            event.preventDefault();
        }
        if (!hasFocus) {
            console.log("False");
            setTimeout(function () {
                commentBody.focus();
            }, 0);
        }
    })  
    // Cancel button
    cancelBtn.addEventListener('click', function cancel() {
        commentBody.innerHTML = originalContent;
        commentBody.contentEditable = false;

        $(saveBtn).fadeToggle('slow');
        $(cancelBtn).fadeToggle('slow');
        $(editBtn).removeClass('disabled');

        this.removeEventListener('click', cancel);
        document.removeEventListener('mousedown', preventBlur);
    })

    // Save button
    saveBtn.addEventListener('click', function save() {

        input.value = commentBody.innerHTML;

        commentBody.contentEditable = false;
        document.getElementById()

        $(saveBtn).fadeToggle('slow');
        $(cancelBtn).fadeToggle('slow');
        $(editBtn).removeClass('disabled');

        this.removeEventListener('click', save);
        document.removeEventListener('mousedown', preventBlur);
    })

    commentBody.contentEditable = true;
    commentBody.focus();
    
    
}

$(document).ready(edit);


/* THREAD MODAL */
//$(document).ready(function () {
//    console.log("ready!");

//    var threadModal = document.getElementById('threadModal')
//    threadModal.addEventListener("hide.bs.modal", function (e) {
//        console.log("Modal closed")

//        if (confirm("Are you sure, you want to close?")) return true;

//        else return false;
//    });
//});


/* COMMENT BOX TABS (BOOTSTRAP) */
const triggerTabList = document.querySelectorAll('#commentTab button')
triggerTabList.forEach(triggerEl => {
    const tabTrigger = new bootstrap.Tab(triggerEl)

    triggerEl.addEventListener('click', event => {
        event.preventDefault()
        tabTrigger.show()
    })
})


/* BACK TO TOP BUTTON */
var btn = $('#back-to-top-button');

$(window).scroll(function () {
    if ($(window).scrollTop() > 700) {
        btn.addClass('show');
    } else {
        btn.removeClass('show');
    }
});
btn.on('click', function (e) {
    e.preventDefault();
    $('html, body').animate({ scrollTop: 0 }, '300');
});


/* GUEST/MEMBER SWITCH */
var memberSwitch = $('#guest-switch');
var guestSwitch = $('#member-switch');

var memberToast = document.getElementById("member-toast")
var guestToast = document.getElementById("guest-toast")

var memberOnlyElements = Array.from(document.getElementsByClassName('member-only'));
var guestOnlyElements = Array.from(document.getElementsByClassName('guest-only'));
var guestDisabledElements = Array.from(document.getElementsByClassName('guest-disabled'));

memberSwitch.on('click', function () {
    console.log("Member switch pressed. You are now a guest");

    /* Switch buttons */
    guestSwitch.addClass('show');
    memberSwitch.removeClass('show');

    /* Toast */
    const my_member_toast = bootstrap.Toast.getOrCreateInstance(guestToast);
    my_member_toast.show();

    /* Hide guest elements and show member elements */

    memberOnlyElements.forEach(el => {
        $(el).addClass('hide');
    })

    guestOnlyElements.forEach(el => {
        $(el).removeClass('hide');
    })

    guestDisabledElements.forEach(el => {
        $(el).addClass('disabled');
    })
});

guestSwitch.on('click', function () {
    console.log("Guest switch pressed. You are now a member");

    /* Switch buttons */
    memberSwitch.addClass('show');
    guestSwitch.removeClass('show');

    /* Toast */
    const my_guest_toast = bootstrap.Toast.getOrCreateInstance(memberToast);
    my_guest_toast.show();

    /* Hide member elements and show guest elements */

    guestOnlyElements.forEach(el => {
        $(el).addClass('hide');
    })

    memberOnlyElements.forEach(el => {
        $(el).removeClass('hide');
    })

    guestDisabledElements.forEach(el => {
        $(el).removeClass('disabled');
    })
});

/* COMMENT BOX PREVIEW */
window.addEventListener('load', function () {
    console.log("Window loaded");

    //if (window.jQuery) {
    //    // jQuery is loaded  
    //    alert("jQuery is working!");
    //} else {
    //    // jQuery is not loaded
    //    alert("jQuery is not working");
    //}

    function commentPreview() {
        var previewContent = document.getElementById('comment').value;
        if (previewContent.trim().length === 0) {
            return false;
        } else {
            document.getElementById('preview-content').innerHTML = previewContent;
            return false;
        }
    }
    document.getElementById('preview-tab').onclick = commentPreview;
})


/* COMMENT BOX TABS (BOOTSTRAP) */
//const triggerTabList = document.querySelectorAll('#commentTab button')
//triggerTabList.forEach(triggerEl => {
//    const tabTrigger = new bootstrap.Tab(triggerEl)

//    triggerEl.addEventListener('click', event => {
//        event.preventDefault()
//        tabTrigger.show()
//    })
//})


/* SHARE MODAL */
var exampleModal = document.getElementById('shareModal')
exampleModal.addEventListener('show.bs.modal', function (event) {

    // Button that triggered the modal
    var button = event.relatedTarget
    // Extract info from data-bs-* attributes
    var recipient = button.getAttribute('data-bs-id')
    console.log(recipient)
    // If necessary, you could initiate an AJAX request here
    // and then do the updating in a callback.
    //
    // Update the modal's content.
    var modalBodyInput = exampleModal.querySelector('.modal-body input')
    modalBodyInput.value = "https://localhost:7054/thread/container/" + recipient
})

console.log("End of MyScript.js")

