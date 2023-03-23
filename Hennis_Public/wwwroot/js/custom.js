function ShowStaffImageModal() {
    $('#detailModal').modal('show');
}

function HideStaffImageModal() {
    $("#detailModal").modal('hide');
}

function InitShowMoreFunction() {
    $(document).on("click", ".show-more button", function (e) {
        
        var $this = $(this);

        var $content = $this.parent().prev("div.content");
        var linkText = $this.text().toUpperCase();

        if (linkText === "SHOW MORE") {
            linkText = "Show less";
            $content.removeClass('hideContent');
            $content.addClass('showContent');
            //$content.switchClass("hideContent", "showContent", 400);
        } else {
            linkText = "Show more";
            $content.removeClass('showContent');
            $content.addClass('hideContent');
            //$content.switchClass("showContent", "hideContent", 400);
        }

        $(this).text(linkText);
    })
}

window.initializeCarousel = () => {
    $('.carousel').carousel({ interval: 2000 });
}