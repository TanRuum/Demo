/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.filebrowserBrowseUrl = "/frontend/js/ckeditor/plugin/ckfinder/ckfinder.html";
    config.filebrowserImageUrl = "/frontend/js/ckeditor/plugin/ckfinder/ckfinder.htfml?type=Images";
    config.filebrowserFlashUrl = "/frontend/js/ckeditor/plugin/ckfinder/ckfinder.html?type=Flash";
    config.filebrowserUploadUrl = "/frontend/js/ckeditor/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
    config.filebrowserImageUploadUrl = "/frontend/js/ckeditor/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    config.filebrowserFlashUploadUrl = "/frontend/js/ckeditor/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

    config.extraPlugins = 'youtube';
    config.youtube_responsive = true;
};
