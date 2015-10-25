using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace Framework
{
    /// <summary>
    /// MIME Content Types
    /// </summary>
    public enum MIMEContentTypes
    {
		//[Description("application")]
		application,
		//[Description("audio")]
		audio,
		//[Description("chemical")]
		chemical,
		//[Description("drawing")]
		drawing,
		//[Description("image")]
		image,
		//[Description("i-world")]
		i_world,
		//[Description("message")]
		message,
		//[Description("model")]
		model,
		//[Description("multipart")]
		multipart,
		//[Description("music")]
		music,
		//[Description("paleovu")]
		paleovu,
		//[Description("text")]
		text,
		//[Description("video")]
		video,
		//[Description("windows")]
		windows,
		//[Description("www")]
		www,
		//[Description("x-conference")]
		x_conference,
		//[Description("xgl")]
		xgl,
		//[Description("x-music")]
		x_music,
		//[Description("x-world")]
		x_world,
    }

    /// <summary>
    /// MIME Content SubTypes
    /// </summary>   
	public enum MIMEContentSubTypes
    {
		//[Description("acad")]
		acad,
		//[Description("aiff")]
		aiff,
		//[Description("animaflex")]
		animaflex,
		//[Description("arj")]
		arj,
		//[Description("asp")]
		asp,
		//[Description("avi")]
		avi,
		//[Description("avs-video")]
		avs_video,
		//[Description("base64")]
		base64,
		//[Description("basic")]
		basic,
		//[Description("binhex")]
		binhex,
		//[Description("binhex4")]
		binhex4,
		//[Description("bmp")]
		bmp,
		//[Description("book")]
		book,
		//[Description("cdf")]
		cdf,
		//[Description("clariscad")]
		clariscad,
		//[Description("cmu-raster")]
		cmu_raster,
		//[Description("commonground")]
		commonground,
		//[Description("crescendo")]
		crescendo,
		//[Description("css")]
		css,
		//[Description("dl")]
		dl,
		//[Description("drafting")]
		drafting,
		//[Description("drawing")]
		drawing,
		//[Description("dsptype")]
		dsptype,
		//[Description("dxf")]
		dxf,
		//[Description("envoy")]
		envoy,
		//[Description("excel")]
		excel,
		//[Description("fif")]
		fif,
		//[Description("fli")]
		fli,
		//[Description("florian")]
		florian,
		//[Description("fractals")]
		fractals,
		//[Description("freeloader")]
		freeloader,
		//[Description("futuresplash")]
		futuresplash,
		//[Description("g3fax")]
		g3fax,
		//[Description("gif")]
		gif,
		//[Description("gl")]
		gl,
		//[Description("gnutar")]
		gnutar,
		//[Description("groupwise")]
		groupwise,
		//[Description("hlp")]
		hlp,
		//[Description("hta")]
		hta,
		//[Description("html")]
		html,
		//[Description("i-deas")]
		i_deas,
		//[Description("ief")]
		ief,
		//[Description("iges")]
		iges,
		//[Description("inf")]
		inf,
		//[Description("it")]
		it,
		//[Description("i-vrml")]
		i_vrml,
		//[Description("java")]
		java,
		//[Description("java-byte-code")]
		java_byte_code,
		//[Description("jpeg")]
		jpeg,
		//[Description("jutvision")]
		jutvision,
		//[Description("lha")]
		lha,
		//[Description("lzx")]
		lzx,
		//[Description("macbinary")]
		macbinary,
		//[Description("mac-binary")]
		mac_binary,
		//[Description("mac-binhex")]
		mac_binhex,
		//[Description("mac-binhex40")]
		mac_binhex40,
		//[Description("mac-compactpro")]
		mac_compactpro,
		//[Description("make")]
		make,
		//[Description("make.my.funk")]
		make_my_funk,
		//[Description("marc")]
		marc,
		//[Description("mbedlet")]
		mbedlet,
		//[Description("mcad")]
		mcad,
		//[Description("mcf")]
		mcf,
		//[Description("metafile")]
		metafile,
		//[Description("mid")]
		mid,
		//[Description("midi")]
		midi,
		//[Description("mime")]
		mime,
		//[Description("mod")]
		mod,
		//[Description("movie")]
		movie,
		//[Description("mpeg")]
		mpeg,
		//[Description("mpeg3")]
		mpeg3,
		//[Description("mspowerpoint")]
		mspowerpoint,
		//[Description("msvideo")]
		msvideo,
		//[Description("msword")]
		msword,
		//[Description("mswrite")]
		mswrite,
		//[Description("naplps")]
		naplps,
		//[Description("netmc")]
		netmc,
		//[Description("nspaudio")]
		nspaudio,
		//[Description("octet-stream")]
		octet_stream,
		//[Description("oda")]
		oda,
		//[Description("pascal")]
		pascal,
		//[Description("pdf")]
		pdf,
		//[Description("pict")]
		pict,
		//[Description("pjpeg")]
		pjpeg,
		//[Description("pkcs10")]
		pkcs10,
		//[Description("pkcs-12")]
		pkcs_12,
		//[Description("pkcs7-mime")]
		pkcs7_mime,
		//[Description("pkcs7-signature")]
		pkcs7_signature,
		//[Description("pkcs-crl")]
		pkcs_crl,
		//[Description("pkix-cert")]
		pkix_cert,
		//[Description("pkix-crl")]
		pkix_crl,
		//[Description("plain")]
		plain,
		//[Description("png")]
		png,
		//[Description("postscript")]
		postscript,
		//[Description("powerpoint")]
		powerpoint,
		//[Description("pro_eng")]
		pro_eng,
		//[Description("quicktime")]
		quicktime,
		//[Description("rfc822")]
		rfc822,
		//[Description("richtext")]
		richtext,
		//[Description("ringing-tones")]
		ringing_tones,
		//[Description("rtf")]
		rtf,
		//[Description("s3m")]
		s3m,
		//[Description("scriplet")]
		scriplet,
		//[Description("sdp")]
		sdp,
		//[Description("sea")]
		sea,
		//[Description("set")]
		set,
		//[Description("sgml")]
		sgml,
		//[Description("sla")]
		sla,
		//[Description("smil")]
		smil,
		//[Description("solids")]
		solids,
		//[Description("sounder")]
		sounder,
		//[Description("step")]
		step,
		//[Description("streamingmedia")]
		streamingmedia,
		//[Description("tab-separated-values")]
		tab_separated_values,
		//[Description("tiff")]
		tiff,
		//[Description("toolbook")]
		toolbook,
		//[Description("tsp-audio")]
		tsp_audio,
		//[Description("tsplayer")]
		tsplayer,
		//[Description("uri-list")]
		uri_list,
		//[Description("vasa")]
		vasa,
		//[Description("vda")]
		vda,
		//[Description("vdo")]
		vdo,
		//[Description("vivo")]
		vivo,
		//[Description("vnd.abc")]
		vnd_abc,
		//[Description("vnd.dwf")]
		vnd_dwf,
		//[Description("vnd.dwg")]
		vnd_dwg,
		//[Description("vnd.fdf")]
		vnd_fdf,
		//[Description("vnd.fmi.flexstor")]
		vnd_fmi_flexstor,
		//[Description("vnd.fpx")]
		vnd_fpx,
		//[Description("vnd.hp-hpgl")]
		vnd_hp_hpgl,
		//[Description("vnd.hp-pcl")]
		vnd_hp_pcl,
		//[Description("vnd.ms-excel")]
		vnd_ms_excel,
		//[Description("vnd.ms-pki.certstore")]
		vnd_ms_pki_certstore,
		//[Description("vnd.ms-pki.pko")]
		vnd_ms_pki_pko,
		//[Description("vnd.ms-pki.seccat")]
		vnd_ms_pki_seccat,
		//[Description("vnd.ms-pki.stl")]
		vnd_ms_pki_stl,
		//[Description("vnd.ms-powerpoint")]
		vnd_ms_powerpoint,
		//[Description("vnd.ms-project")]
		vnd_ms_project,
		//[Description("vnd.net-fpx")]
		vnd_net_fpx,
		//[Description("vnd.nokia.configuration-message")]
		vnd_nokia_configuration_message,
		//[Description("vnd.nokia.ringing-tone")]
		vnd_nokia_ringing_tone,
		//[Description("vnd.qcelp")]
		vnd_qcelp,
		//[Description("vnd.rn-realflash")]
		vnd_rn_realflash,
		//[Description("vnd.rn-realmedia")]
		vnd_rn_realmedia,
		//[Description("vnd.rn-realpix")]
		vnd_rn_realpix,
		//[Description("vnd.rn-realplayer")]
		vnd_rn_realplayer,
		//[Description("vnd.rn-realtext")]
		vnd_rn_realtext,
		//[Description("vnd.rn-realvideo")]
		vnd_rn_realvideo,
		//[Description("vnd.vivo")]
		vnd_vivo,
		//[Description("vnd.wap.wbmp")]
		vnd_wap_wbmp,
		//[Description("vnd.wap.wml")]
		vnd_wap_wml,
		//[Description("vnd.wap.wmlc")]
		vnd_wap_wmlc,
		//[Description("vnd.wap.wmlscript")]
		vnd_wap_wmlscript,
		//[Description("vnd.wap.wmlscriptc")]
		vnd_wap_wmlscriptc,
		//[Description("vnd.xara")]
		vnd_xara,
		//[Description("vnd.xiff")]
		vnd_xiff,
		//[Description("voc")]
		voc,
		//[Description("vocaltec-media-desc")]
		vocaltec_media_desc,
		//[Description("vocaltec-media-file")]
		vocaltec_media_file,
		//[Description("vosaic")]
		vosaic,
		//[Description("voxware")]
		voxware,
		//[Description("vrml")]
		vrml,
		//[Description("wav")]
		wav,
		//[Description("webviewhtml")]
		webviewhtml,
		//[Description("wordperfect")]
		wordperfect,
		//[Description("wordperfect6.0")]
		wordperfect6_0,
		//[Description("wordperfect6.1")]
		wordperfect6_1,
		//[Description("x-123")]
		x_123,
		//[Description("x-3dmf")]
		x_3dmf,
		//[Description("x-adpcm")]
		x_adpcm,
		//[Description("x-aiff")]
		x_aiff,
		//[Description("x-aim")]
		x_aim,
		//[Description("x-amt-demorun")]
		x_amt_demorun,
		//[Description("x-amt-showrun")]
		x_amt_showrun,
		//[Description("x-asm")]
		x_asm,
		//[Description("x-atomic3d-feature")]
		x_atomic3d_feature,
		//[Description("x-au")]
		x_au,
		//[Description("x-audiosoft-intra")]
		x_audiosoft_intra,
		//[Description("x-authorware-bin")]
		x_authorware_bin,
		//[Description("x-authorware-map")]
		x_authorware_map,
		//[Description("x-authorware-seg")]
		x_authorware_seg,
		//[Description("x-bcpio")]
		x_bcpio,
		//[Description("x-binary")]
		x_binary,
		//[Description("x-binhex40")]
		x_binhex40,
		//[Description("xbm")]
		xbm,
		//[Description("x-bsh")]
		x_bsh,
		//[Description("x-bytecode.elisp (compiled elisp)")]
		x_bytecode_elisp__compiled_elisp_,
		//[Description("x-bytecode.python")]
		x_bytecode_python,
		//[Description("x-bzip")]
		x_bzip,
		//[Description("x-bzip2")]
		x_bzip2,
		//[Description("x-c")]
		x_c,
		//[Description("x-cdf")]
		x_cdf,
		//[Description("x-cdlink")]
		x_cdlink,
		//[Description("x-chat")]
		x_chat,
		//[Description("x-cmu-raster")]
		x_cmu_raster,
		//[Description("x-cocoa")]
		x_cocoa,
		//[Description("x-compactpro")]
		x_compactpro,
		//[Description("x-component")]
		x_component,
		//[Description("x-compress")]
		x_compress,
		//[Description("x-compressed")]
		x_compressed,
		//[Description("x-conference")]
		x_conference,
		//[Description("x-cooltalk")]
		x_cooltalk,
		//[Description("x-cpio")]
		x_cpio,
		//[Description("x-cpt")]
		x_cpt,
		//[Description("x-csh")]
		x_csh,
		//[Description("x-deepv")]
		x_deepv,
		//[Description("x-director")]
		x_director,
		//[Description("x-dl")]
		x_dl,
		//[Description("x-dv")]
		x_dv,
		//[Description("x-dvi")]
		x_dvi,
		//[Description("x-dwf (old)")]
		x_dwf__old_,
		//[Description("x-dwg")]
		x_dwg,
		//[Description("x-elc")]
		x_elc,
		//[Description("x-envoy")]
		x_envoy,
		//[Description("x-esrehber")]
		x_esrehber,
		//[Description("x-excel")]
		x_excel,
		//[Description("x-fli")]
		x_fli,
		//[Description("x-fortran")]
		x_fortran,
		//[Description("x-frame")]
		x_frame,
		//[Description("x-freelance")]
		x_freelance,
		//[Description("x-gl")]
		x_gl,
		//[Description("x-gsm")]
		x_gsm,
		//[Description("x-gsp")]
		x_gsp,
		//[Description("x-gss")]
		x_gss,
		//[Description("x-gtar")]
		x_gtar,
		//[Description("x-gzip")]
		x_gzip,
		//[Description("x-h")]
		x_h,
		//[Description("x-hdf")]
		x_hdf,
		//[Description("x-helpfile")]
		x_helpfile,
		//[Description("x-httpd-imap")]
		x_httpd_imap,
		//[Description("x-icon")]
		x_icon,
		//[Description("x-ima")]
		x_ima,
		//[Description("x-internett-signup")]
		x_internett_signup,
		//[Description("x-inventor")]
		x_inventor,
		//[Description("x-ip2")]
		x_ip2,
		//[Description("x-isvideo")]
		x_isvideo,
		//[Description("x-jam")]
		x_jam,
		//[Description("x-java-class")]
		x_java_class,
		//[Description("x-java-commerce")]
		x_java_commerce,
		//[Description("x-javascript")]
		x_javascript,
		//[Description("x-java-source")]
		x_java_source,
		//[Description("x-jg")]
		x_jg,
		//[Description("x-jps")]
		x_jps,
		//[Description("x-karaoke")]
		x_karaoke,
		//[Description("x-koan")]
		x_koan,
		//[Description("x-ksh")]
		x_ksh,
		//[Description("x-la-asf")]
		x_la_asf,
		//[Description("x-latex")]
		x_latex,
		//[Description("x-lha")]
		x_lha,
		//[Description("x-lisp")]
		x_lisp,
		//[Description("x-liveaudio")]
		x_liveaudio,
		//[Description("x-livescreen")]
		x_livescreen,
		//[Description("x-lotus")]
		x_lotus,
		//[Description("x-lotusscreencam")]
		x_lotusscreencam,
		//[Description("x-lzh")]
		x_lzh,
		//[Description("x-lzx")]
		x_lzx,
		//[Description("xm")]
		xm,
		//[Description("x-m")]
		x_m,
		//[Description("x-macbinary")]
		x_macbinary,
		//[Description("x-mac-binhex40")]
		x_mac_binhex40,
		//[Description("x-magic-cap-package-1.0")]
		x_magic_cap_package_1_0,
		//[Description("x-mathcad")]
		x_mathcad,
		//[Description("x-meme")]
		x_meme,
		//[Description("x-mid")]
		x_mid,
		//[Description("x-midi")]
		x_midi,
		//[Description("x-mif")]
		x_mif,
		//[Description("x-mix-transfer")]
		x_mix_transfer,
		//[Description("xml")]
		xml,
		//[Description("x-mod")]
		x_mod,
		//[Description("x-motion-jpeg")]
		x_motion_jpeg,
		//[Description("x-mpeg")]
		x_mpeg,
		//[Description("x-mpeg-3")]
		x_mpeg_3,
		//[Description("x-mpeq2a")]
		x_mpeq2a,
		//[Description("x-mpequrl")]
		x_mpequrl,
		//[Description("x-mplayer2")]
		x_mplayer2,
		//[Description("x-ms-asf")]
		x_ms_asf,
		//[Description("x-ms-asf-plugin")]
		x_ms_asf_plugin,
		//[Description("x-msexcel")]
		x_msexcel,
		//[Description("x-mspowerpoint")]
		x_mspowerpoint,
		//[Description("x-msvideo")]
		x_msvideo,
		//[Description("x-navi-animation")]
		x_navi_animation,
		//[Description("x-navidoc")]
		x_navidoc,
		//[Description("x-navimap")]
		x_navimap,
		//[Description("x-navistyle")]
		x_navistyle,
		//[Description("x-netcdf")]
		x_netcdf,
		//[Description("x-newton-compatible-pkg")]
		x_newton_compatible_pkg,
		//[Description("x-niff")]
		x_niff,
		//[Description("x-nokia-9000-communicator-add-on-software")]
		x_nokia_9000_communicator_add_on_software,
		//[Description("x-nspaudio")]
		x_nspaudio,
		//[Description("x-omc")]
		x_omc,
		//[Description("x-omcdatamaker")]
		x_omcdatamaker,
		//[Description("x-omcregerator")]
		x_omcregerator,
		//[Description("x-pagemaker")]
		x_pagemaker,
		//[Description("x-pascal")]
		x_pascal,
		//[Description("x-pcl")]
		x_pcl,
		//[Description("x-pcx")]
		x_pcx,
		//[Description("x-pdb")]
		x_pdb,
		//[Description("x-pict")]
		x_pict,
		//[Description("x-pixclscript")]
		x_pixclscript,
		//[Description("x-pkcs10")]
		x_pkcs10,
		//[Description("x-pkcs12")]
		x_pkcs12,
		//[Description("x-pkcs7-certificates")]
		x_pkcs7_certificates,
		//[Description("x-pkcs7-certreqresp")]
		x_pkcs7_certreqresp,
		//[Description("x-pkcs7-mime")]
		x_pkcs7_mime,
		//[Description("x-pkcs7-signature")]
		x_pkcs7_signature,
		//[Description("xpm")]
		xpm,
		//[Description("x-pn-realaudio")]
		x_pn_realaudio,
		//[Description("x-pn-realaudio-plugin")]
		x_pn_realaudio_plugin,
		//[Description("x-pointplus")]
		x_pointplus,
		//[Description("x-portable-anymap")]
		x_portable_anymap,
		//[Description("x-portable-bitmap")]
		x_portable_bitmap,
		//[Description("x-portable-graymap")]
		x_portable_graymap,
		//[Description("x-portable-greymap")]
		x_portable_greymap,
		//[Description("x-portable-pixmap")]
		x_portable_pixmap,
		//[Description("x-pov")]
		x_pov,
		//[Description("x-project")]
		x_project,
		//[Description("x-psid")]
		x_psid,
		//[Description("x-pv")]
		x_pv,
		//[Description("x-qpro")]
		x_qpro,
		//[Description("x-qtc")]
		x_qtc,
		//[Description("x-quicktime")]
		x_quicktime,
		//[Description("x-realaudio")]
		x_realaudio,
		//[Description("x-rgb")]
		x_rgb,
		//[Description("x-rtf")]
		x_rtf,
		//[Description("x-scm")]
		x_scm,
		//[Description("x-script")]
		x_script,
		//[Description("x-script.csh")]
		x_script_csh,
		//[Description("x-script.elisp")]
		x_script_elisp,
		//[Description("x-script.guile")]
		x_script_guile,
		//[Description("x-script.ksh")]
		x_script_ksh,
		//[Description("x-script.lisp")]
		x_script_lisp,
		//[Description("x-script.perl")]
		x_script_perl,
		//[Description("x-script.perl-module")]
		x_script_perl_module,
		//[Description("x-script.phyton")]
		x_script_phyton,
		//[Description("x-script.rexx")]
		x_script_rexx,
		//[Description("x-script.scheme")]
		x_script_scheme,
		//[Description("x-script.sh")]
		x_script_sh,
		//[Description("x-script.tcl")]
		x_script_tcl,
		//[Description("x-script.tcsh")]
		x_script_tcsh,
		//[Description("x-script.zsh")]
		x_script_zsh,
		//[Description("x-sdp")]
		x_sdp,
		//[Description("x-sea")]
		x_sea,
		//[Description("x-seelogo")]
		x_seelogo,
		//[Description("x-server-parsed-html")]
		x_server_parsed_html,
		//[Description("x-setext")]
		x_setext,
		//[Description("x-sgi-movie")]
		x_sgi_movie,
		//[Description("x-sgml")]
		x_sgml,
		//[Description("x-sh")]
		x_sh,
		//[Description("x-shar")]
		x_shar,
		//[Description("x-shockwave-flash")]
		x_shockwave_flash,
		//[Description("x-sit")]
		x_sit,
		//[Description("x-speech")]
		x_speech,
		//[Description("x-sprite")]
		x_sprite,
		//[Description("x-stuffit")]
		x_stuffit,
		//[Description("x-sv4cpio")]
		x_sv4cpio,
		//[Description("x-sv4crc")]
		x_sv4crc,
		//[Description("x-svr")]
		x_svr,
		//[Description("x-tar")]
		x_tar,
		//[Description("x-tbook")]
		x_tbook,
		//[Description("x-tcl")]
		x_tcl,
		//[Description("x-tex")]
		x_tex,
		//[Description("x-texinfo")]
		x_texinfo,
		//[Description("x-tiff")]
		x_tiff,
		//[Description("x-troff")]
		x_troff,
		//[Description("x-troff-man")]
		x_troff_man,
		//[Description("x-troff-me")]
		x_troff_me,
		//[Description("x-troff-ms")]
		x_troff_ms,
		//[Description("x-troff-msvideo")]
		x_troff_msvideo,
		//[Description("x-twinvq")]
		x_twinvq,
		//[Description("x-twinvq-plugin")]
		x_twinvq_plugin,
		//[Description("x-uil")]
		x_uil,
		//[Description("x-ustar")]
		x_ustar,
		//[Description("x-uuencode")]
		x_uuencode,
		//[Description("x-vcalendar")]
		x_vcalendar,
		//[Description("x-visio")]
		x_visio,
		//[Description("x-vnd.audioexplosion.mjuicemediafile")]
		x_vnd_audioexplosion_mjuicemediafile,
		//[Description("x-vnd.audioexplosion.mzz")]
		x_vnd_audioexplosion_mzz,
		//[Description("x-vnd.ls-xpix")]
		x_vnd_ls_xpix,
		//[Description("x-voc")]
		x_voc,
		//[Description("x-vrml")]
		x_vrml,
		//[Description("x-vrt")]
		x_vrt,
		//[Description("x-wais-source")]
		x_wais_source,
		//[Description("x-wav")]
		x_wav,
		//[Description("x-windows-bmp")]
		x_windows_bmp,
		//[Description("x-winhelp")]
		x_winhelp,
		//[Description("x-wintalk")]
		x_wintalk,
		//[Description("x-world")]
		x_world,
		//[Description("x-wpwin")]
		x_wpwin,
		//[Description("x-wri")]
		x_wri,
		//[Description("x-x509-ca-cert")]
		x_x509_ca_cert,
		//[Description("x-x509-user-cert")]
		x_x509_user_cert,
		//[Description("x-xbitmap")]
		x_xbitmap,
		//[Description("x-xbm")]
		x_xbm,
		//[Description("x-xpixmap")]
		x_xpixmap,
		//[Description("x-xwd")]
		x_xwd,
		//[Description("x-xwindowdump")]
		x_xwindowdump,
		//[Description("x-zip")]
		x_zip,
		//[Description("x-zip-compressed")]
		x_zip_compressed,
		//[Description("zip")]
		zip,
    }
	
    /// <summary>
    /// File Extensions for MIME types and sub Types
    /// </summary>
    public enum FileExtensions
    {
		//[Description(".3dm")]
		_3dm,
		//[Description(".3dmf")]
		_3dmf,
		//[Description(".a")]
		_a,
		//[Description(".aab")]
		_aab,
		//[Description(".aam")]
		_aam,
		//[Description(".aas")]
		_aas,
		//[Description(".abc")]
		_abc,
		//[Description(".acgi")]
		_acgi,
		//[Description(".afl")]
		_afl,
		//[Description(".ai")]
		_ai,
		//[Description(".aif")]
		_aif,
		//[Description(".aifc")]
		_aifc,
		//[Description(".aiff")]
		_aiff,
		//[Description(".aim")]
		_aim,
		//[Description(".aip")]
		_aip,
		//[Description(".ani")]
		_ani,
		//[Description(".aos")]
		_aos,
		//[Description(".aps")]
		_aps,
		//[Description(".arc")]
		_arc,
		//[Description(".arj")]
		_arj,
		//[Description(".art")]
		_art,
		//[Description(".asf")]
		_asf,
		//[Description(".asm")]
		_asm,
		//[Description(".asp")]
		_asp,
		//[Description(".asx")]
		_asx,
		//[Description(".au")]
		_au,
		//[Description(".avi")]
		_avi,
		//[Description(".avs")]
		_avs,
		//[Description(".bcpio")]
		_bcpio,
		//[Description(".bin")]
		_bin,
		//[Description(".bm")]
		_bm,
		//[Description(".bmp")]
		_bmp,
		//[Description(".boo")]
		_boo,
		//[Description(".book")]
		_book,
		//[Description(".boz")]
		_boz,
		//[Description(".bsh")]
		_bsh,
		//[Description(".bz")]
		_bz,
		//[Description(".bz2")]
		_bz2,
		//[Description(".c")]
		_c,
		//[Description(".c++")]
		_c__,
		//[Description(".cat")]
		_cat,
		//[Description(".cc")]
		_cc,
		//[Description(".ccad")]
		_ccad,
		//[Description(".cco")]
		_cco,
		//[Description(".cdf")]
		_cdf,
		//[Description(".cer")]
		_cer,
		//[Description(".cha")]
		_cha,
		//[Description(".chat")]
		_chat,
		//[Description(".class")]
		_class,
		//[Description(".com")]
		_com,
		//[Description(".conf")]
		_conf,
		//[Description(".cpio")]
		_cpio,
		//[Description(".cpp")]
		_cpp,
		//[Description(".cpt")]
		_cpt,
		//[Description(".crl")]
		_crl,
		//[Description(".crt")]
		_crt,
		//[Description(".csh")]
		_csh,
		//[Description(".css")]
		_css,
		//[Description(".cxx")]
		_cxx,
		//[Description(".dcr")]
		_dcr,
		//[Description(".deepv")]
		_deepv,
		//[Description(".def")]
		_def,
		//[Description(".der")]
		_der,
		//[Description(".dif")]
		_dif,
		//[Description(".dir")]
		_dir,
		//[Description(".dl")]
		_dl,
		//[Description(".doc")]
		_doc,
		//[Description(".dot")]
		_dot,
		//[Description(".dp")]
		_dp,
		//[Description(".drw")]
		_drw,
		//[Description(".dump")]
		_dump,
		//[Description(".dv")]
		_dv,
		//[Description(".dvi")]
		_dvi,
		//[Description(".dwf")]
		_dwf,
		//[Description(".dwg")]
		_dwg,
		//[Description(".dxf")]
		_dxf,
		//[Description(".dxr")]
		_dxr,
		//[Description(".el")]
		_el,
		//[Description(".elc")]
		_elc,
		//[Description(".env")]
		_env,
		//[Description(".eps")]
		_eps,
		//[Description(".es")]
		_es,
		//[Description(".etx")]
		_etx,
		//[Description(".evy")]
		_evy,
		//[Description(".exe")]
		_exe,
		//[Description(".f")]
		_f,
		//[Description(".f77")]
		_f77,
		//[Description(".f90")]
		_f90,
		//[Description(".fdf")]
		_fdf,
		//[Description(".fif")]
		_fif,
		//[Description(".fli")]
		_fli,
		//[Description(".flo")]
		_flo,
		//[Description(".flx")]
		_flx,
		//[Description(".fmf")]
		_fmf,
		//[Description(".for")]
		_for,
		//[Description(".fpx")]
		_fpx,
		//[Description(".frl")]
		_frl,
		//[Description(".funk")]
		_funk,
		//[Description(".g")]
		_g,
		//[Description(".g3")]
		_g3,
		//[Description(".gif")]
		_gif,
		//[Description(".gl")]
		_gl,
		//[Description(".gsd")]
		_gsd,
		//[Description(".gsm")]
		_gsm,
		//[Description(".gsp")]
		_gsp,
		//[Description(".gss")]
		_gss,
		//[Description(".gtar")]
		_gtar,
		//[Description(".gz")]
		_gz,
		//[Description(".gzip")]
		_gzip,
		//[Description(".h")]
		_h,
		//[Description(".hdf")]
		_hdf,
		//[Description(".help")]
		_help,
		//[Description(".hgl")]
		_hgl,
		//[Description(".hh")]
		_hh,
		//[Description(".hlb")]
		_hlb,
		//[Description(".hlp")]
		_hlp,
		//[Description(".hpg")]
		_hpg,
		//[Description(".hpgl")]
		_hpgl,
		//[Description(".hqx")]
		_hqx,
		//[Description(".hta")]
		_hta,
		//[Description(".htc")]
		_htc,
		//[Description(".htm")]
		_htm,
		//[Description(".html")]
		_html,
		//[Description(".htmls")]
		_htmls,
		//[Description(".htt")]
		_htt,
		//[Description(".htx")]
		_htx,
		//[Description(".ice")]
		_ice,
		//[Description(".ico")]
		_ico,
		//[Description(".idc")]
		_idc,
		//[Description(".ief")]
		_ief,
		//[Description(".iefs")]
		_iefs,
		//[Description(".iges")]
		_iges,
		//[Description(".igs")]
		_igs,
		//[Description(".ima")]
		_ima,
		//[Description(".imap")]
		_imap,
		//[Description(".inf")]
		_inf,
		//[Description(".ins")]
		_ins,
		//[Description(".ip")]
		_ip,
		//[Description(".isu")]
		_isu,
		//[Description(".it")]
		_it,
		//[Description(".iv")]
		_iv,
		//[Description(".ivr")]
		_ivr,
		//[Description(".ivy")]
		_ivy,
		//[Description(".jam")]
		_jam,
		//[Description(".jav")]
		_jav,
		//[Description(".java")]
		_java,
		//[Description(".jcm")]
		_jcm,
		//[Description(".jfif")]
		_jfif,
		//[Description(".jfif-tbnl")]
		_jfif_tbnl,
		//[Description(".jpe")]
		_jpe,
		//[Description(".jpeg")]
		_jpeg,
		//[Description(".jpg")]
		_jpg,
		//[Description(".jps")]
		_jps,
		//[Description(".js")]
		_js,
		//[Description(".jut")]
		_jut,
		//[Description(".kar")]
		_kar,
		//[Description(".ksh")]
		_ksh,
		//[Description(".la")]
		_la,
		//[Description(".lam")]
		_lam,
		//[Description(".latex")]
		_latex,
		//[Description(".lha")]
		_lha,
		//[Description(".lhx")]
		_lhx,
		//[Description(".list")]
		_list,
		//[Description(".lma")]
		_lma,
		//[Description(".log")]
		_log,
		//[Description(".lsp")]
		_lsp,
		//[Description(".lst")]
		_lst,
		//[Description(".lsx")]
		_lsx,
		//[Description(".ltx")]
		_ltx,
		//[Description(".lzh")]
		_lzh,
		//[Description(".lzx")]
		_lzx,
		//[Description(".m")]
		_m,
		//[Description(".m1v")]
		_m1v,
		//[Description(".m2a")]
		_m2a,
		//[Description(".m2v")]
		_m2v,
		//[Description(".m3u")]
		_m3u,
		//[Description(".man")]
		_man,
		//[Description(".map")]
		_map,
		//[Description(".mar")]
		_mar,
		//[Description(".mbd")]
		_mbd,
		//[Description(".mc$")]
		_mc_,
		//[Description(".mcd")]
		_mcd,
		//[Description(".mcf")]
		_mcf,
		//[Description(".mcp")]
		_mcp,
		//[Description(".me")]
		_me,
		//[Description(".mht")]
		_mht,
		//[Description(".mhtml")]
		_mhtml,
		//[Description(".mid")]
		_mid,
		//[Description(".midi")]
		_midi,
		//[Description(".mif")]
		_mif,
		//[Description(".mime")]
		_mime,
		//[Description(".mjf")]
		_mjf,
		//[Description(".mjpg")]
		_mjpg,
		//[Description(".mm")]
		_mm,
		//[Description(".mme")]
		_mme,
		//[Description(".mod")]
		_mod,
		//[Description(".moov")]
		_moov,
		//[Description(".mov")]
		_mov,
		//[Description(".movie")]
		_movie,
		//[Description(".mp2")]
		_mp2,
		//[Description(".mp3")]
		_mp3,
		//[Description(".mpa")]
		_mpa,
		//[Description(".mpc")]
		_mpc,
		//[Description(".mpe")]
		_mpe,
		//[Description(".mpeg")]
		_mpeg,
		//[Description(".mpg")]
		_mpg,
		//[Description(".mpga")]
		_mpga,
		//[Description(".mpp")]
		_mpp,
		//[Description(".mpt")]
		_mpt,
		//[Description(".mpv")]
		_mpv,
		//[Description(".mpx")]
		_mpx,
		//[Description(".mrc")]
		_mrc,
		//[Description(".ms")]
		_ms,
		//[Description(".mv")]
		_mv,
		//[Description(".my")]
		_my,
		//[Description(".mzz")]
		_mzz,
		//[Description(".nap")]
		_nap,
		//[Description(".naplps")]
		_naplps,
		//[Description(".nc")]
		_nc,
		//[Description(".ncm")]
		_ncm,
		//[Description(".nif")]
		_nif,
		//[Description(".niff")]
		_niff,
		//[Description(".nix")]
		_nix,
		//[Description(".nsc")]
		_nsc,
		//[Description(".nvd")]
		_nvd,
		//[Description(".o")]
		_o,
		//[Description(".oda")]
		_oda,
		//[Description(".omc")]
		_omc,
		//[Description(".omcd")]
		_omcd,
		//[Description(".omcr")]
		_omcr,
		//[Description(".p")]
		_p,
		//[Description(".p10")]
		_p10,
		//[Description(".p12")]
		_p12,
		//[Description(".p7a")]
		_p7a,
		//[Description(".p7c")]
		_p7c,
		//[Description(".p7m")]
		_p7m,
		//[Description(".p7r")]
		_p7r,
		//[Description(".p7s")]
		_p7s,
		//[Description(".part")]
		_part,
		//[Description(".pas")]
		_pas,
		//[Description(".pbm")]
		_pbm,
		//[Description(".pcl")]
		_pcl,
		//[Description(".pct")]
		_pct,
		//[Description(".pcx")]
		_pcx,
		//[Description(".pdb")]
		_pdb,
		//[Description(".pdf")]
		_pdf,
		//[Description(".pfunk")]
		_pfunk,
		//[Description(".pgm")]
		_pgm,
		//[Description(".pic")]
		_pic,
		//[Description(".pict")]
		_pict,
		//[Description(".pkg")]
		_pkg,
		//[Description(".pko")]
		_pko,
		//[Description(".pl")]
		_pl,
		//[Description(".plx")]
		_plx,
		//[Description(".pm")]
		_pm,
		//[Description(".pm4")]
		_pm4,
		//[Description(".pm5")]
		_pm5,
		//[Description(".png")]
		_png,
		//[Description(".pnm")]
		_pnm,
		//[Description(".pot")]
		_pot,
		//[Description(".pov")]
		_pov,
		//[Description(".ppa")]
		_ppa,
		//[Description(".ppm")]
		_ppm,
		//[Description(".pps")]
		_pps,
		//[Description(".ppt")]
		_ppt,
		//[Description(".ppz")]
		_ppz,
		//[Description(".pre")]
		_pre,
		//[Description(".prt")]
		_prt,
		//[Description(".ps")]
		_ps,
		//[Description(".psd")]
		_psd,
		//[Description(".pvu")]
		_pvu,
		//[Description(".pwz")]
		_pwz,
		//[Description(".py")]
		_py,
		//[Description(".pyc")]
		_pyc,
		//[Description(".qcp")]
		_qcp,
		//[Description(".qd3")]
		_qd3,
		//[Description(".qd3d")]
		_qd3d,
		//[Description(".qif")]
		_qif,
		//[Description(".qt")]
		_qt,
		//[Description(".qtc")]
		_qtc,
		//[Description(".qti")]
		_qti,
		//[Description(".qtif")]
		_qtif,
		//[Description(".ra")]
		_ra,
		//[Description(".ram")]
		_ram,
		//[Description(".ras")]
		_ras,
		//[Description(".rast")]
		_rast,
		//[Description(".rexx")]
		_rexx,
		//[Description(".rf")]
		_rf,
		//[Description(".rgb")]
		_rgb,
		//[Description(".rm")]
		_rm,
		//[Description(".rmi")]
		_rmi,
		//[Description(".rmm")]
		_rmm,
		//[Description(".rmp")]
		_rmp,
		//[Description(".rng")]
		_rng,
		//[Description(".rnx")]
		_rnx,
		//[Description(".roff")]
		_roff,
		//[Description(".rp")]
		_rp,
		//[Description(".rpm")]
		_rpm,
		//[Description(".rt")]
		_rt,
		//[Description(".rtf")]
		_rtf,
		//[Description(".rtx")]
		_rtx,
		//[Description(".rv")]
		_rv,
		//[Description(".s")]
		_s,
		//[Description(".s3m")]
		_s3m,
		//[Description(".saveme")]
		_saveme,
		//[Description(".sbk")]
		_sbk,
		//[Description(".scm")]
		_scm,
		//[Description(".sdml")]
		_sdml,
		//[Description(".sdp")]
		_sdp,
		//[Description(".sdr")]
		_sdr,
		//[Description(".sea")]
		_sea,
		//[Description(".set")]
		_set,
		//[Description(".sgm")]
		_sgm,
		//[Description(".sgml")]
		_sgml,
		//[Description(".sh")]
		_sh,
		//[Description(".shar")]
		_shar,
		//[Description(".shtml")]
		_shtml,
		//[Description(".sid")]
		_sid,
		//[Description(".sit")]
		_sit,
		//[Description(".skd")]
		_skd,
		//[Description(".skm")]
		_skm,
		//[Description(".skp")]
		_skp,
		//[Description(".skt")]
		_skt,
		//[Description(".sl")]
		_sl,
		//[Description(".smi")]
		_smi,
		//[Description(".smil")]
		_smil,
		//[Description(".snd")]
		_snd,
		//[Description(".sol")]
		_sol,
		//[Description(".spc")]
		_spc,
		//[Description(".spl")]
		_spl,
		//[Description(".spr")]
		_spr,
		//[Description(".sprite")]
		_sprite,
		//[Description(".src")]
		_src,
		//[Description(".ssi")]
		_ssi,
		//[Description(".ssm")]
		_ssm,
		//[Description(".sst")]
		_sst,
		//[Description(".step")]
		_step,
		//[Description(".stl")]
		_stl,
		//[Description(".stp")]
		_stp,
		//[Description(".sv4cpio")]
		_sv4cpio,
		//[Description(".sv4crc")]
		_sv4crc,
		//[Description(".svf")]
		_svf,
		//[Description(".svr")]
		_svr,
		//[Description(".swf")]
		_swf,
		//[Description(".t")]
		_t,
		//[Description(".talk")]
		_talk,
		//[Description(".tar")]
		_tar,
		//[Description(".tbk")]
		_tbk,
		//[Description(".tcl")]
		_tcl,
		//[Description(".tcsh")]
		_tcsh,
		//[Description(".tex")]
		_tex,
		//[Description(".texi")]
		_texi,
		//[Description(".texinfo")]
		_texinfo,
		//[Description(".text")]
		_text,
		//[Description(".tgz")]
		_tgz,
		//[Description(".tif")]
		_tif,
		//[Description(".tiff")]
		_tiff,
		//[Description(".tr")]
		_tr,
		//[Description(".tsi")]
		_tsi,
		//[Description(".tsp")]
		_tsp,
		//[Description(".tsv")]
		_tsv,
		//[Description(".turbot")]
		_turbot,
		//[Description(".txt")]
		_txt,
		//[Description(".uil")]
		_uil,
		//[Description(".uni")]
		_uni,
		//[Description(".unis")]
		_unis,
		//[Description(".unv")]
		_unv,
		//[Description(".uri")]
		_uri,
		//[Description(".uris")]
		_uris,
		//[Description(".ustar")]
		_ustar,
		//[Description(".uu")]
		_uu,
		//[Description(".uue")]
		_uue,
		//[Description(".vcd")]
		_vcd,
		//[Description(".vcs")]
		_vcs,
		//[Description(".vda")]
		_vda,
		//[Description(".vdo")]
		_vdo,
		//[Description(".vew")]
		_vew,
		//[Description(".viv")]
		_viv,
		//[Description(".vivo")]
		_vivo,
		//[Description(".vmd")]
		_vmd,
		//[Description(".vmf")]
		_vmf,
		//[Description(".voc")]
		_voc,
		//[Description(".vos")]
		_vos,
		//[Description(".vox")]
		_vox,
		//[Description(".vqe")]
		_vqe,
		//[Description(".vqf")]
		_vqf,
		//[Description(".vql")]
		_vql,
		//[Description(".vrml")]
		_vrml,
		//[Description(".vrt")]
		_vrt,
		//[Description(".vsd")]
		_vsd,
		//[Description(".vst")]
		_vst,
		//[Description(".vsw")]
		_vsw,
		//[Description(".w60")]
		_w60,
		//[Description(".w61")]
		_w61,
		//[Description(".w6w")]
		_w6w,
		//[Description(".wav")]
		_wav,
		//[Description(".wb1")]
		_wb1,
		//[Description(".wbmp")]
		_wbmp,
		//[Description(".web")]
		_web,
		//[Description(".wiz")]
		_wiz,
		//[Description(".wk1")]
		_wk1,
		//[Description(".wmf")]
		_wmf,
		//[Description(".wml")]
		_wml,
		//[Description(".wmlc")]
		_wmlc,
		//[Description(".wmls")]
		_wmls,
		//[Description(".wmlsc")]
		_wmlsc,
		//[Description(".word")]
		_word,
		//[Description(".wp")]
		_wp,
		//[Description(".wp5")]
		_wp5,
		//[Description(".wp6")]
		_wp6,
		//[Description(".wpd")]
		_wpd,
		//[Description(".wq1")]
		_wq1,
		//[Description(".wri")]
		_wri,
		//[Description(".wrl")]
		_wrl,
		//[Description(".wrz")]
		_wrz,
		//[Description(".wsc")]
		_wsc,
		//[Description(".wsrc")]
		_wsrc,
		//[Description(".wtk")]
		_wtk,
		//[Description(".xbm")]
		_xbm,
		//[Description(".xdr")]
		_xdr,
		//[Description(".xgz")]
		_xgz,
		//[Description(".xif")]
		_xif,
		//[Description(".xl")]
		_xl,
		//[Description(".xla")]
		_xla,
		//[Description(".xlb")]
		_xlb,
		//[Description(".xlc")]
		_xlc,
		//[Description(".xld")]
		_xld,
		//[Description(".xlk")]
		_xlk,
		//[Description(".xll")]
		_xll,
		//[Description(".xlm")]
		_xlm,
		//[Description(".xls")]
		_xls,
		//[Description(".xlt")]
		_xlt,
		//[Description(".xlv")]
		_xlv,
		//[Description(".xlw")]
		_xlw,
		//[Description(".xm")]
		_xm,
		//[Description(".xml")]
		_xml,
		//[Description(".xmz")]
		_xmz,
		//[Description(".xpix")]
		_xpix,
		//[Description(".xpm")]
		_xpm,
		//[Description(".x-png")]
		_x_png,
		//[Description(".xsr")]
		_xsr,
		//[Description(".xwd")]
		_xwd,
		//[Description(".xyz")]
		_xyz,
		//[Description(".z")]
		_z,
		//[Description(".zip")]
		_zip,
		//[Description(".zoo")]
		_zoo,
		//[Description(".zsh")]
		_zsh,
    }


    /// <summary>
    /// mapping from MIMEContentType To FileExtension
    /// </summary>
    public class MIMEContentTypeToFileExtensionMappingItem
    {
        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
		public MIMEContentTypes ContentType { get; set; }

        /// <summary>
        /// Gets or sets the content type in string.
        /// </summary>
        /// <value>
        /// The content type in string.
        /// </value>
		public string ContentTypeInString { get; set; }
		 /// <summary>
        /// Gets or sets the type of the content sub.
        /// </summary>
        /// <value>
        /// The type of the content sub.
        /// </value>
		public MIMEContentSubTypes ContentSubType { get; set; }
        /// <summary>
        /// Gets or sets the content sub type in string.
        /// </summary>
        /// <value>
        /// The content sub type in string.
        /// </value>
		public string ContentSubTypeInString { get; set; }
        /// <summary>
        /// Gets or sets the full name of the content sub type.
        /// </summary>
        /// <value>
        /// The full name of the content sub type.
        /// </value>
        public string ContentSubTypeFullName { get; set; }
        /// <summary>
        /// Gets or sets the file extension.
        /// </summary>
        /// <value>
        /// The file extension.
        /// </value>
		public FileExtensions  FileExtension { get; set; }
        /// <summary>
        /// Gets or sets the file extension in string.
        /// </summary>
        /// <value>
        /// The file extension in string.
        /// </value>
		public string FileExtensionInString { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
		public bool IsDefault { get; set; }

        /// <summary>
        /// Gets the full type of the content.
        /// </summary>
        /// <value>
        /// The full type of the content.
        /// </value>
        public string FullContentType
        {
            get
            {
                return string.Format("{0}/{1}", this.ContentTypeInString, this.ContentSubType);
            }
        }
    }
	
    /// <summary>
    /// mapping collection from MIMEContentType To FileExtension
    /// </summary>
    public class MIMEContentTypeToFileExtensionMappingCollection : List<MIMEContentTypeToFileExtensionMappingItem>
    {
		#region Add(...)

        /// <summary>
        /// Adds the specified content type.
        /// </summary>
        /// <param name="ContentType">Type of the content.</param>
        /// <param name="ContentTypeInString">The content type in string.</param>
        /// <param name="ContentSubType">Type of the content sub.</param>
        /// <param name="ContentSubTypeInString">The content sub type in string.</param>
        /// <param name="FileExtension">The file extension.</param>
        /// <param name="FileExtensionInString">The file extension in string.</param>
        /// <param name="IsDefault">if set to <c>true</c> [is default].</param>
		public void Add(
            MIMEContentTypes ContentType
            , string ContentTypeInString
            , MIMEContentSubTypes   ContentSubType
            , string ContentSubTypeInString
            , FileExtensions FileExtension
            , string FileExtensionInString
            , bool IsDefault
            )
        {
            MIMEContentTypeToFileExtensionMappingItem _Item = new MIMEContentTypeToFileExtensionMappingItem();
            _Item.ContentType = ContentType;
            _Item.ContentTypeInString = ContentTypeInString;
            _Item.ContentSubType = ContentSubType;
            _Item.ContentSubTypeInString = ContentSubTypeInString;
            _Item.FileExtension = FileExtension;
            _Item.FileExtensionInString = FileExtensionInString;
            _Item.IsDefault = IsDefault;
            _Item.ContentSubTypeFullName = string.Format("{0}/{1}", _Item.ContentTypeInString, _Item.ContentSubTypeInString);
            this.Add(_Item);
        }

		#endregion Add(...)

		#region PrediacteByFileExtension

        /// <summary>
        /// PrediacteByFileExtension
        /// </summary>        
		private class PrediacteByFileExtension
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PrediacteByFileExtension"/> class.
            /// </summary>
            /// <param name="comparedToFileExtension">The compared to file extension.</param>
			public PrediacteByFileExtension(string comparedToFileExtension)
            {
                if (string.IsNullOrWhiteSpace(comparedToFileExtension) == false)
                {
                    if (comparedToFileExtension.ToCharArray()[0] == '.')
                    {
                        this.ComparedToFileExtension = comparedToFileExtension;
                    }
                    else
                    {
                        this.ComparedToFileExtension = string.Format(".{0}", comparedToFileExtension);
                    }
                }
			}
            

            /// <summary>
            /// Gets or sets the compared to file extension.
            /// </summary>
            /// <value>
            /// The compared to file extension.
            /// </value>
			private string ComparedToFileExtension { get; set; }

            /// <summary>
            /// Predicates the specified input.
            /// </summary>
            /// <param name="input">The input.</param>
            /// <returns>true if meets criteria, otherwise false</returns>
            public bool Predicate(MIMEContentTypeToFileExtensionMappingItem input)
            {
                return string.IsNullOrWhiteSpace(this.ComparedToFileExtension) == false && input!= null && input.FileExtensionInString == ComparedToFileExtension;
            }
        }

        /// <summary>
        /// Existses the by file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public bool ExistsByFileExtension(string fileExtension)
        {
            return this.Count(t => t.FileExtensionInString == fileExtension) > 0;
        }
        /// <summary>
        /// Gets the by file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns><see cref="MIMEContentTypeToFileExtensionMappingItem"/></returns>
        public MIMEContentTypeToFileExtensionMappingItem GetByFileExtension(string fileExtension)
        {
            return this.Single(t => t.FileExtensionInString == fileExtension);
        }

        /// <summary>
        /// Gets the list by file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns>a generic list</returns>
        protected List<MIMEContentTypeToFileExtensionMappingItem> GetListByFileExtension(string fileExtension)
        {
            List<MIMEContentTypeToFileExtensionMappingItem> _retval = new List<MIMEContentTypeToFileExtensionMappingItem>();
            _retval.AddRange(this.Where(t => t.FileExtensionInString == fileExtension));
            return _retval;
        }

		

        /// <summary>
        /// Gets the collection by file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns><see cref="MIMEContentTypeToFileExtensionMappingCollection"/></returns>
        public MIMEContentTypeToFileExtensionMappingCollection GetCollectionByFileExtension(string fileExtension)
        {
            MIMEContentTypeToFileExtensionMappingCollection _retval = new MIMEContentTypeToFileExtensionMappingCollection();
            _retval.AddRange(this.Where(t => t.FileExtensionInString == fileExtension));
            return _retval;
        }

        #endregion PrediacteByFileExtension

		#region GetDefault()

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <returns><see cref="MIMEContentTypeToFileExtensionMappingCollection"/></returns>
		public static MIMEContentTypeToFileExtensionMappingCollection GetDefault()
		{
			MIMEContentTypeToFileExtensionMappingCollection _retval = new MIMEContentTypeToFileExtensionMappingCollection();

            _retval.Add(MIMEContentTypes.x_world, "x-world", MIMEContentSubTypes.x_3dmf, "x-3dmf", FileExtensions._3dm, ".3dm", false);
            _retval.Add(MIMEContentTypes.x_world, "x-world", MIMEContentSubTypes.x_3dmf, "x-3dmf", FileExtensions._3dmf, ".3dmf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._a, ".a", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_authorware_bin, "x-authorware-bin", FileExtensions._aab, ".aab", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_authorware_map, "x-authorware-map", FileExtensions._aam, ".aam", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_authorware_seg, "x-authorware-seg", FileExtensions._aas, ".aas", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.vnd_abc, "vnd.abc", FileExtensions._abc, ".abc", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.html, "html", FileExtensions._acgi, ".acgi", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.animaflex, "animaflex", FileExtensions._afl, ".afl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.postscript, "postscript", FileExtensions._ai, ".ai", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.aiff, "aiff", FileExtensions._aif, ".aif", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_aiff, "x-aiff", FileExtensions._aif, ".aif", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.aiff, "aiff", FileExtensions._aifc, ".aifc", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_aiff, "x-aiff", FileExtensions._aifc, ".aifc", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.aiff, "aiff", FileExtensions._aiff, ".aiff", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_aiff, "x-aiff", FileExtensions._aiff, ".aiff", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_aim, "x-aim", FileExtensions._aim, ".aim", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_audiosoft_intra, "x-audiosoft-intra", FileExtensions._aip, ".aip", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_navi_animation, "x-navi-animation", FileExtensions._ani, ".ani", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_nokia_9000_communicator_add_on_software, "x-nokia-9000-communicator-add-on-software", FileExtensions._aos, ".aos", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mime, "mime", FileExtensions._aps, ".aps", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._arc, ".arc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.arj, "arj", FileExtensions._arj, ".arj", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._arj, ".arj", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_jg, "x-jg", FileExtensions._art, ".art", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_ms_asf, "x-ms-asf", FileExtensions._asf, ".asf", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_asm, "x-asm", FileExtensions._asm, ".asm", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.asp, "asp", FileExtensions._asp, ".asp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_mplayer2, "x-mplayer2", FileExtensions._asx, ".asx", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_ms_asf, "x-ms-asf", FileExtensions._asx, ".asx", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_ms_asf_plugin, "x-ms-asf-plugin", FileExtensions._asx, ".asx", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.basic, "basic", FileExtensions._au, ".au", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_au, "x-au", FileExtensions._au, ".au", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_troff_msvideo, "x-troff-msvideo", FileExtensions._avi, ".avi", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.avi, "avi", FileExtensions._avi, ".avi", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.msvideo, "msvideo", FileExtensions._avi, ".avi", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_msvideo, "x-msvideo", FileExtensions._avi, ".avi", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.avs_video, "avs-video", FileExtensions._avs, ".avs", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_bcpio, "x-bcpio", FileExtensions._bcpio, ".bcpio", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mac_binary, "mac-binary", FileExtensions._bin, ".bin", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.macbinary, "macbinary", FileExtensions._bin, ".bin", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._bin, ".bin", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_binary, "x-binary", FileExtensions._bin, ".bin", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_macbinary, "x-macbinary", FileExtensions._bin, ".bin", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.bmp, "bmp", FileExtensions._bm, ".bm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.bmp, "bmp", FileExtensions._bmp, ".bmp", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_windows_bmp, "x-windows-bmp", FileExtensions._bmp, ".bmp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.book, "book", FileExtensions._boo, ".boo", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.book, "book", FileExtensions._book, ".book", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_bzip2, "x-bzip2", FileExtensions._boz, ".boz", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_bsh, "x-bsh", FileExtensions._bsh, ".bsh", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_bzip, "x-bzip", FileExtensions._bz, ".bz", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_bzip2, "x-bzip2", FileExtensions._bz2, ".bz2", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._c, ".c", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_c, "x-c", FileExtensions._c, ".c", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._c__, ".c++", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_pki_seccat, "vnd.ms-pki.seccat", FileExtensions._cat, ".cat", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._cc, ".cc", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_c, "x-c", FileExtensions._cc, ".cc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.clariscad, "clariscad", FileExtensions._ccad, ".ccad", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_cocoa, "x-cocoa", FileExtensions._cco, ".cco", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.cdf, "cdf", FileExtensions._cdf, ".cdf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_cdf, "x-cdf", FileExtensions._cdf, ".cdf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_netcdf, "x-netcdf", FileExtensions._cdf, ".cdf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pkix_cert, "pkix-cert", FileExtensions._cer, ".cer", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_x509_ca_cert, "x-x509-ca-cert", FileExtensions._cer, ".cer", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_chat, "x-chat", FileExtensions._cha, ".cha", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_chat, "x-chat", FileExtensions._chat, ".chat", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.java, "java", FileExtensions._class, ".class", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.java_byte_code, "java-byte-code", FileExtensions._class, ".class", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_java_class, "x-java-class", FileExtensions._class, ".class", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._com, ".com", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._com, ".com", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._conf, ".conf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_cpio, "x-cpio", FileExtensions._cpio, ".cpio", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_c, "x-c", FileExtensions._cpp, ".cpp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mac_compactpro, "mac-compactpro", FileExtensions._cpt, ".cpt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_compactpro, "x-compactpro", FileExtensions._cpt, ".cpt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_cpt, "x-cpt", FileExtensions._cpt, ".cpt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pkcs_crl, "pkcs-crl", FileExtensions._crl, ".crl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pkix_crl, "pkix-crl", FileExtensions._crl, ".crl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pkix_cert, "pkix-cert", FileExtensions._crt, ".crt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_x509_ca_cert, "x-x509-ca-cert", FileExtensions._crt, ".crt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_x509_user_cert, "x-x509-user-cert", FileExtensions._crt, ".crt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_csh, "x-csh", FileExtensions._csh, ".csh", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_csh, "x-script.csh", FileExtensions._csh, ".csh", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pointplus, "x-pointplus", FileExtensions._css, ".css", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.css, "css", FileExtensions._css, ".css", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._cxx, ".cxx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_director, "x-director", FileExtensions._dcr, ".dcr", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_deepv, "x-deepv", FileExtensions._deepv, ".deepv", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._def, ".def", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_x509_ca_cert, "x-x509-ca-cert", FileExtensions._der, ".der", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_dv, "x-dv", FileExtensions._dif, ".dif", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_director, "x-director", FileExtensions._dir, ".dir", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.dl, "dl", FileExtensions._dl, ".dl", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_dl, "x-dl", FileExtensions._dl, ".dl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.msword, "msword", FileExtensions._doc, ".doc", true);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.msword, "msword", FileExtensions._dot, ".dot", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.commonground, "commonground", FileExtensions._dp, ".dp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.drafting, "drafting", FileExtensions._drw, ".drw", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._dump, ".dump", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_dv, "x-dv", FileExtensions._dv, ".dv", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_dvi, "x-dvi", FileExtensions._dvi, ".dvi", false);
            _retval.Add(MIMEContentTypes.drawing, "drawing", MIMEContentSubTypes.x_dwf__old_, "x-dwf (old)", FileExtensions._dwf, ".dwf", false);
            _retval.Add(MIMEContentTypes.model, "model", MIMEContentSubTypes.vnd_dwf, "vnd.dwf", FileExtensions._dwf, ".dwf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.acad, "acad", FileExtensions._dwg, ".dwg", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vnd_dwg, "vnd.dwg", FileExtensions._dwg, ".dwg", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_dwg, "x-dwg", FileExtensions._dwg, ".dwg", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.dxf, "dxf", FileExtensions._dxf, ".dxf", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vnd_dwg, "vnd.dwg", FileExtensions._dxf, ".dxf", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_dwg, "x-dwg", FileExtensions._dxf, ".dxf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_director, "x-director", FileExtensions._dxr, ".dxr", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_elisp, "x-script.elisp", FileExtensions._el, ".el", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_bytecode_elisp__compiled_elisp_, "x-bytecode.elisp (compiled elisp)", FileExtensions._elc, ".elc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_elc, "x-elc", FileExtensions._elc, ".elc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_envoy, "x-envoy", FileExtensions._env, ".env", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.postscript, "postscript", FileExtensions._eps, ".eps", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_esrehber, "x-esrehber", FileExtensions._es, ".es", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_setext, "x-setext", FileExtensions._etx, ".etx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.envoy, "envoy", FileExtensions._evy, ".evy", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_envoy, "x-envoy", FileExtensions._evy, ".evy", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._exe, ".exe", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._f, ".f", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_fortran, "x-fortran", FileExtensions._f, ".f", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_fortran, "x-fortran", FileExtensions._f77, ".f77", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._f90, ".f90", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_fortran, "x-fortran", FileExtensions._f90, ".f90", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_fdf, "vnd.fdf", FileExtensions._fdf, ".fdf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.fractals, "fractals", FileExtensions._fif, ".fif", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.fif, "fif", FileExtensions._fif, ".fif", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.fli, "fli", FileExtensions._fli, ".fli", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_fli, "x-fli", FileExtensions._fli, ".fli", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.florian, "florian", FileExtensions._flo, ".flo", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.vnd_fmi_flexstor, "vnd.fmi.flexstor", FileExtensions._flx, ".flx", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_atomic3d_feature, "x-atomic3d-feature", FileExtensions._fmf, ".fmf", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._for, ".for", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_fortran, "x-fortran", FileExtensions._for, ".for", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vnd_fpx, "vnd.fpx", FileExtensions._fpx, ".fpx", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vnd_net_fpx, "vnd.net-fpx", FileExtensions._fpx, ".fpx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.freeloader, "freeloader", FileExtensions._frl, ".frl", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.make, "make", FileExtensions._funk, ".funk", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._g, ".g", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.g3fax, "g3fax", FileExtensions._g3, ".g3", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.gif, "gif", FileExtensions._gif, ".gif", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.gl, "gl", FileExtensions._gl, ".gl", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_gl, "x-gl", FileExtensions._gl, ".gl", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_gsm, "x-gsm", FileExtensions._gsd, ".gsd", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_gsm, "x-gsm", FileExtensions._gsm, ".gsm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_gsp, "x-gsp", FileExtensions._gsp, ".gsp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_gss, "x-gss", FileExtensions._gss, ".gss", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_gtar, "x-gtar", FileExtensions._gtar, ".gtar", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_compressed, "x-compressed", FileExtensions._gz, ".gz", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_gzip, "x-gzip", FileExtensions._gz, ".gz", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_gzip, "x-gzip", FileExtensions._gzip, ".gzip", false);
            _retval.Add(MIMEContentTypes.multipart, "multipart", MIMEContentSubTypes.x_gzip, "x-gzip", FileExtensions._gzip, ".gzip", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._h, ".h", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_h, "x-h", FileExtensions._h, ".h", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_hdf, "x-hdf", FileExtensions._hdf, ".hdf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_helpfile, "x-helpfile", FileExtensions._help, ".help", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_hp_hpgl, "vnd.hp-hpgl", FileExtensions._hgl, ".hgl", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._hh, ".hh", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_h, "x-h", FileExtensions._hh, ".hh", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script, "x-script", FileExtensions._hlb, ".hlb", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.hlp, "hlp", FileExtensions._hlp, ".hlp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_helpfile, "x-helpfile", FileExtensions._hlp, ".hlp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_winhelp, "x-winhelp", FileExtensions._hlp, ".hlp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_hp_hpgl, "vnd.hp-hpgl", FileExtensions._hpg, ".hpg", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_hp_hpgl, "vnd.hp-hpgl", FileExtensions._hpgl, ".hpgl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.binhex, "binhex", FileExtensions._hqx, ".hqx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.binhex4, "binhex4", FileExtensions._hqx, ".hqx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mac_binhex, "mac-binhex", FileExtensions._hqx, ".hqx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mac_binhex40, "mac-binhex40", FileExtensions._hqx, ".hqx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_binhex40, "x-binhex40", FileExtensions._hqx, ".hqx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_mac_binhex40, "x-mac-binhex40", FileExtensions._hqx, ".hqx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.hta, "hta", FileExtensions._hta, ".hta", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_component, "x-component", FileExtensions._htc, ".htc", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.html, "html", FileExtensions._htm, ".htm", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.html, "html", FileExtensions._html, ".html", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.html, "html", FileExtensions._htmls, ".htmls", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.webviewhtml, "webviewhtml", FileExtensions._htt, ".htt", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.html, "html", FileExtensions._htx, ".htx", false);
            _retval.Add(MIMEContentTypes.x_conference, "x-conference", MIMEContentSubTypes.x_cooltalk, "x-cooltalk", FileExtensions._ice, ".ice", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_icon, "x-icon", FileExtensions._ico, ".ico", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._idc, ".idc", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.ief, "ief", FileExtensions._ief, ".ief", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.ief, "ief", FileExtensions._iefs, ".iefs", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.iges, "iges", FileExtensions._iges, ".iges", false);
            _retval.Add(MIMEContentTypes.model, "model", MIMEContentSubTypes.iges, "iges", FileExtensions._iges, ".iges", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.iges, "iges", FileExtensions._igs, ".igs", false);
            _retval.Add(MIMEContentTypes.model, "model", MIMEContentSubTypes.iges, "iges", FileExtensions._igs, ".igs", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_ima, "x-ima", FileExtensions._ima, ".ima", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_httpd_imap, "x-httpd-imap", FileExtensions._imap, ".imap", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.inf, "inf", FileExtensions._inf, ".inf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_internett_signup, "x-internett-signup", FileExtensions._ins, ".ins", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_ip2, "x-ip2", FileExtensions._ip, ".ip", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_isvideo, "x-isvideo", FileExtensions._isu, ".isu", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.it, "it", FileExtensions._it, ".it", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_inventor, "x-inventor", FileExtensions._iv, ".iv", false);
            _retval.Add(MIMEContentTypes.i_world, "i-world", MIMEContentSubTypes.i_vrml, "i-vrml", FileExtensions._ivr, ".ivr", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_livescreen, "x-livescreen", FileExtensions._ivy, ".ivy", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_jam, "x-jam", FileExtensions._jam, ".jam", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._jav, ".jav", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_java_source, "x-java-source", FileExtensions._jav, ".jav", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._java, ".java", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_java_source, "x-java-source", FileExtensions._java, ".java", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_java_commerce, "x-java-commerce", FileExtensions._jcm, ".jcm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.jpeg, "jpeg", FileExtensions._jfif, ".jfif", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.pjpeg, "pjpeg", FileExtensions._jfif, ".jfif", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.jpeg, "jpeg", FileExtensions._jfif_tbnl, ".jfif-tbnl", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.jpeg, "jpeg", FileExtensions._jpe, ".jpe", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.pjpeg, "pjpeg", FileExtensions._jpe, ".jpe", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.jpeg, "jpeg", FileExtensions._jpeg, ".jpeg", true);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.pjpeg, "pjpeg", FileExtensions._jpeg, ".jpeg", true);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.jpeg, "jpeg", FileExtensions._jpg, ".jpg", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.pjpeg, "pjpeg", FileExtensions._jpg, ".jpg", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_jps, "x-jps", FileExtensions._jps, ".jps", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_javascript, "x-javascript", FileExtensions._js, ".js", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.jutvision, "jutvision", FileExtensions._jut, ".jut", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.midi, "midi", FileExtensions._kar, ".kar", false);
            _retval.Add(MIMEContentTypes.music, "music", MIMEContentSubTypes.x_karaoke, "x-karaoke", FileExtensions._kar, ".kar", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_ksh, "x-ksh", FileExtensions._ksh, ".ksh", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_ksh, "x-script.ksh", FileExtensions._ksh, ".ksh", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.nspaudio, "nspaudio", FileExtensions._la, ".la", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_nspaudio, "x-nspaudio", FileExtensions._la, ".la", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_liveaudio, "x-liveaudio", FileExtensions._lam, ".lam", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_latex, "x-latex", FileExtensions._latex, ".latex", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.lha, "lha", FileExtensions._lha, ".lha", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._lha, ".lha", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_lha, "x-lha", FileExtensions._lha, ".lha", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._lhx, ".lhx", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._list, ".list", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.nspaudio, "nspaudio", FileExtensions._lma, ".lma", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_nspaudio, "x-nspaudio", FileExtensions._lma, ".lma", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._log, ".log", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_lisp, "x-lisp", FileExtensions._lsp, ".lsp", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_lisp, "x-script.lisp", FileExtensions._lsp, ".lsp", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._lst, ".lst", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_la_asf, "x-la-asf", FileExtensions._lsx, ".lsx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_latex, "x-latex", FileExtensions._ltx, ".ltx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._lzh, ".lzh", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_lzh, "x-lzh", FileExtensions._lzh, ".lzh", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.lzx, "lzx", FileExtensions._lzx, ".lzx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._lzx, ".lzx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_lzx, "x-lzx", FileExtensions._lzx, ".lzx", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._m, ".m", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_m, "x-m", FileExtensions._m, ".m", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._m1v, ".m1v", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._m2a, ".m2a", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._m2v, ".m2v", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_mpequrl, "x-mpequrl", FileExtensions._m3u, ".m3u", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_troff_man, "x-troff-man", FileExtensions._man, ".man", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_navimap, "x-navimap", FileExtensions._map, ".map", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._mar, ".mar", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mbedlet, "mbedlet", FileExtensions._mbd, ".mbd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_magic_cap_package_1_0, "x-magic-cap-package-1.0", FileExtensions._mc_, ".mc$", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mcad, "mcad", FileExtensions._mcd, ".mcd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_mathcad, "x-mathcad", FileExtensions._mcd, ".mcd", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vasa, "vasa", FileExtensions._mcf, ".mcf", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.mcf, "mcf", FileExtensions._mcf, ".mcf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.netmc, "netmc", FileExtensions._mcp, ".mcp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_troff_me, "x-troff-me", FileExtensions._me, ".me", false);
            _retval.Add(MIMEContentTypes.message, "message", MIMEContentSubTypes.rfc822, "rfc822", FileExtensions._mht, ".mht", false);
            _retval.Add(MIMEContentTypes.message, "message", MIMEContentSubTypes.rfc822, "rfc822", FileExtensions._mhtml, ".mhtml", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_midi, "x-midi", FileExtensions._mid, ".mid", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.midi, "midi", FileExtensions._mid, ".mid", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_mid, "x-mid", FileExtensions._mid, ".mid", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_midi, "x-midi", FileExtensions._mid, ".mid", false);
            _retval.Add(MIMEContentTypes.music, "music", MIMEContentSubTypes.crescendo, "crescendo", FileExtensions._mid, ".mid", false);
            _retval.Add(MIMEContentTypes.x_music, "x-music", MIMEContentSubTypes.x_midi, "x-midi", FileExtensions._mid, ".mid", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_midi, "x-midi", FileExtensions._midi, ".midi", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.midi, "midi", FileExtensions._midi, ".midi", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_mid, "x-mid", FileExtensions._midi, ".midi", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_midi, "x-midi", FileExtensions._midi, ".midi", false);
            _retval.Add(MIMEContentTypes.music, "music", MIMEContentSubTypes.crescendo, "crescendo", FileExtensions._midi, ".midi", false);
            _retval.Add(MIMEContentTypes.x_music, "x-music", MIMEContentSubTypes.x_midi, "x-midi", FileExtensions._midi, ".midi", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_frame, "x-frame", FileExtensions._mif, ".mif", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_mif, "x-mif", FileExtensions._mif, ".mif", false);
            _retval.Add(MIMEContentTypes.message, "message", MIMEContentSubTypes.rfc822, "rfc822", FileExtensions._mime, ".mime", false);
            _retval.Add(MIMEContentTypes.www, "www", MIMEContentSubTypes.mime, "mime", FileExtensions._mime, ".mime", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_vnd_audioexplosion_mjuicemediafile, "x-vnd.audioexplosion.mjuicemediafile", FileExtensions._mjf, ".mjf", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_motion_jpeg, "x-motion-jpeg", FileExtensions._mjpg, ".mjpg", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.base64, "base64", FileExtensions._mm, ".mm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_meme, "x-meme", FileExtensions._mm, ".mm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.base64, "base64", FileExtensions._mme, ".mme", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.mod, "mod", FileExtensions._mod, ".mod", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_mod, "x-mod", FileExtensions._mod, ".mod", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.quicktime, "quicktime", FileExtensions._moov, ".moov", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.quicktime, "quicktime", FileExtensions._mov, ".mov", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_sgi_movie, "x-sgi-movie", FileExtensions._movie, ".movie", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mp2, ".mp2", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_mpeg, "x-mpeg", FileExtensions._mp2, ".mp2", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mp2, ".mp2", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_mpeg, "x-mpeg", FileExtensions._mp2, ".mp2", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_mpeq2a, "x-mpeq2a", FileExtensions._mp2, ".mp2", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.mpeg3, "mpeg3", FileExtensions._mp3, ".mp3", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_mpeg_3, "x-mpeg-3", FileExtensions._mp3, ".mp3", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mp3, ".mp3", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_mpeg, "x-mpeg", FileExtensions._mp3, ".mp3", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mpa, ".mpa", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mpa, ".mpa", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_project, "x-project", FileExtensions._mpc, ".mpc", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mpe, ".mpe", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mpeg, ".mpeg", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mpg, ".mpg", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mpg, ".mpg", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.mpeg, "mpeg", FileExtensions._mpga, ".mpga", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_project, "vnd.ms-project", FileExtensions._mpp, ".mpp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_project, "x-project", FileExtensions._mpt, ".mpt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_project, "x-project", FileExtensions._mpv, ".mpv", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_project, "x-project", FileExtensions._mpx, ".mpx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.marc, "marc", FileExtensions._mrc, ".mrc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_troff_ms, "x-troff-ms", FileExtensions._ms, ".ms", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_sgi_movie, "x-sgi-movie", FileExtensions._mv, ".mv", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.make, "make", FileExtensions._my, ".my", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_vnd_audioexplosion_mzz, "x-vnd.audioexplosion.mzz", FileExtensions._mzz, ".mzz", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.naplps, "naplps", FileExtensions._nap, ".nap", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.naplps, "naplps", FileExtensions._naplps, ".naplps", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_netcdf, "x-netcdf", FileExtensions._nc, ".nc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_nokia_configuration_message, "vnd.nokia.configuration-message", FileExtensions._ncm, ".ncm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_niff, "x-niff", FileExtensions._nif, ".nif", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_niff, "x-niff", FileExtensions._niff, ".niff", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_mix_transfer, "x-mix-transfer", FileExtensions._nix, ".nix", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_conference, "x-conference", FileExtensions._nsc, ".nsc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_navidoc, "x-navidoc", FileExtensions._nvd, ".nvd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._o, ".o", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.oda, "oda", FileExtensions._oda, ".oda", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_omc, "x-omc", FileExtensions._omc, ".omc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_omcdatamaker, "x-omcdatamaker", FileExtensions._omcd, ".omcd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_omcregerator, "x-omcregerator", FileExtensions._omcr, ".omcr", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_pascal, "x-pascal", FileExtensions._p, ".p", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pkcs10, "pkcs10", FileExtensions._p10, ".p10", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pkcs10, "x-pkcs10", FileExtensions._p10, ".p10", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pkcs_12, "pkcs-12", FileExtensions._p12, ".p12", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pkcs12, "x-pkcs12", FileExtensions._p12, ".p12", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pkcs7_signature, "x-pkcs7-signature", FileExtensions._p7a, ".p7a", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pkcs7_mime, "pkcs7-mime", FileExtensions._p7c, ".p7c", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pkcs7_mime, "x-pkcs7-mime", FileExtensions._p7c, ".p7c", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pkcs7_mime, "pkcs7-mime", FileExtensions._p7m, ".p7m", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pkcs7_mime, "x-pkcs7-mime", FileExtensions._p7m, ".p7m", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pkcs7_certreqresp, "x-pkcs7-certreqresp", FileExtensions._p7r, ".p7r", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pkcs7_signature, "pkcs7-signature", FileExtensions._p7s, ".p7s", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pro_eng, "pro_eng", FileExtensions._part, ".part", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.pascal, "pascal", FileExtensions._pas, ".pas", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_portable_bitmap, "x-portable-bitmap", FileExtensions._pbm, ".pbm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_hp_pcl, "vnd.hp-pcl", FileExtensions._pcl, ".pcl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pcl, "x-pcl", FileExtensions._pcl, ".pcl", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_pict, "x-pict", FileExtensions._pct, ".pct", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_pcx, "x-pcx", FileExtensions._pcx, ".pcx", false);
            _retval.Add(MIMEContentTypes.chemical, "chemical", MIMEContentSubTypes.x_pdb, "x-pdb", FileExtensions._pdb, ".pdb", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pdf, "pdf", FileExtensions._pdf, ".pdf", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.make, "make", FileExtensions._pfunk, ".pfunk", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.make_my_funk, "make.my.funk", FileExtensions._pfunk, ".pfunk", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_portable_graymap, "x-portable-graymap", FileExtensions._pgm, ".pgm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_portable_greymap, "x-portable-greymap", FileExtensions._pgm, ".pgm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.pict, "pict", FileExtensions._pic, ".pic", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.pict, "pict", FileExtensions._pict, ".pict", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_newton_compatible_pkg, "x-newton-compatible-pkg", FileExtensions._pkg, ".pkg", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_pki_pko, "vnd.ms-pki.pko", FileExtensions._pko, ".pko", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._pl, ".pl", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_perl, "x-script.perl", FileExtensions._pl, ".pl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pixclscript, "x-pixclscript", FileExtensions._plx, ".plx", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_xpixmap, "x-xpixmap", FileExtensions._pm, ".pm", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_perl_module, "x-script.perl-module", FileExtensions._pm, ".pm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pagemaker, "x-pagemaker", FileExtensions._pm4, ".pm4", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pagemaker, "x-pagemaker", FileExtensions._pm5, ".pm5", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.png, "png", FileExtensions._png, ".png", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_portable_anymap, "x-portable-anymap", FileExtensions._pnm, ".pnm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_portable_anymap, "x-portable-anymap", FileExtensions._pnm, ".pnm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mspowerpoint, "mspowerpoint", FileExtensions._pot, ".pot", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_powerpoint, "vnd.ms-powerpoint", FileExtensions._pot, ".pot", false);
            _retval.Add(MIMEContentTypes.model, "model", MIMEContentSubTypes.x_pov, "x-pov", FileExtensions._pov, ".pov", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_powerpoint, "vnd.ms-powerpoint", FileExtensions._ppa, ".ppa", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_portable_pixmap, "x-portable-pixmap", FileExtensions._ppm, ".ppm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mspowerpoint, "mspowerpoint", FileExtensions._pps, ".pps", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_powerpoint, "vnd.ms-powerpoint", FileExtensions._pps, ".pps", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mspowerpoint, "mspowerpoint", FileExtensions._ppt, ".ppt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.powerpoint, "powerpoint", FileExtensions._ppt, ".ppt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_powerpoint, "vnd.ms-powerpoint", FileExtensions._ppt, ".ppt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_mspowerpoint, "x-mspowerpoint", FileExtensions._ppt, ".ppt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mspowerpoint, "mspowerpoint", FileExtensions._ppz, ".ppz", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_freelance, "x-freelance", FileExtensions._pre, ".pre", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.pro_eng, "pro_eng", FileExtensions._prt, ".prt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.postscript, "postscript", FileExtensions._ps, ".ps", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._psd, ".psd", false);
            _retval.Add(MIMEContentTypes.paleovu, "paleovu", MIMEContentSubTypes.x_pv, "x-pv", FileExtensions._pvu, ".pvu", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_powerpoint, "vnd.ms-powerpoint", FileExtensions._pwz, ".pwz", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_phyton, "x-script.phyton", FileExtensions._py, ".py", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_bytecode_python, "x-bytecode.python", FileExtensions._pyc, ".pyc", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.vnd_qcelp, "vnd.qcelp", FileExtensions._qcp, ".qcp", false);
            _retval.Add(MIMEContentTypes.x_world, "x-world", MIMEContentSubTypes.x_3dmf, "x-3dmf", FileExtensions._qd3, ".qd3", false);
            _retval.Add(MIMEContentTypes.x_world, "x-world", MIMEContentSubTypes.x_3dmf, "x-3dmf", FileExtensions._qd3d, ".qd3d", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_quicktime, "x-quicktime", FileExtensions._qif, ".qif", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.quicktime, "quicktime", FileExtensions._qt, ".qt", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_qtc, "x-qtc", FileExtensions._qtc, ".qtc", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_quicktime, "x-quicktime", FileExtensions._qti, ".qti", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_quicktime, "x-quicktime", FileExtensions._qtif, ".qtif", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_pn_realaudio, "x-pn-realaudio", FileExtensions._ra, ".ra", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_pn_realaudio_plugin, "x-pn-realaudio-plugin", FileExtensions._ra, ".ra", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_realaudio, "x-realaudio", FileExtensions._ra, ".ra", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_pn_realaudio, "x-pn-realaudio", FileExtensions._ram, ".ram", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_cmu_raster, "x-cmu-raster", FileExtensions._ras, ".ras", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.cmu_raster, "cmu-raster", FileExtensions._ras, ".ras", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_cmu_raster, "x-cmu-raster", FileExtensions._ras, ".ras", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.cmu_raster, "cmu-raster", FileExtensions._rast, ".rast", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_rexx, "x-script.rexx", FileExtensions._rexx, ".rexx", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vnd_rn_realflash, "vnd.rn-realflash", FileExtensions._rf, ".rf", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_rgb, "x-rgb", FileExtensions._rgb, ".rgb", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_rn_realmedia, "vnd.rn-realmedia", FileExtensions._rm, ".rm", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_pn_realaudio, "x-pn-realaudio", FileExtensions._rm, ".rm", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.mid, "mid", FileExtensions._rmi, ".rmi", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_pn_realaudio, "x-pn-realaudio", FileExtensions._rmm, ".rmm", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_pn_realaudio, "x-pn-realaudio", FileExtensions._rmp, ".rmp", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_pn_realaudio_plugin, "x-pn-realaudio-plugin", FileExtensions._rmp, ".rmp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.ringing_tones, "ringing-tones", FileExtensions._rng, ".rng", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_nokia_ringing_tone, "vnd.nokia.ringing-tone", FileExtensions._rng, ".rng", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_rn_realplayer, "vnd.rn-realplayer", FileExtensions._rnx, ".rnx", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_troff, "x-troff", FileExtensions._roff, ".roff", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vnd_rn_realpix, "vnd.rn-realpix", FileExtensions._rp, ".rp", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_pn_realaudio_plugin, "x-pn-realaudio-plugin", FileExtensions._rpm, ".rpm", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.richtext, "richtext", FileExtensions._rt, ".rt", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.vnd_rn_realtext, "vnd.rn-realtext", FileExtensions._rt, ".rt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.rtf, "rtf", FileExtensions._rtf, ".rtf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_rtf, "x-rtf", FileExtensions._rtf, ".rtf", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.richtext, "richtext", FileExtensions._rtf, ".rtf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.rtf, "rtf", FileExtensions._rtx, ".rtx", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.richtext, "richtext", FileExtensions._rtx, ".rtx", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.vnd_rn_realvideo, "vnd.rn-realvideo", FileExtensions._rv, ".rv", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_asm, "x-asm", FileExtensions._s, ".s", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.s3m, "s3m", FileExtensions._s3m, ".s3m", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._saveme, ".saveme", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_tbook, "x-tbook", FileExtensions._sbk, ".sbk", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_lotusscreencam, "x-lotusscreencam", FileExtensions._scm, ".scm", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_guile, "x-script.guile", FileExtensions._scm, ".scm", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_scheme, "x-script.scheme", FileExtensions._scm, ".scm", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_scm, "x-scm", FileExtensions._scm, ".scm", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._sdml, ".sdml", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.sdp, "sdp", FileExtensions._sdp, ".sdp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_sdp, "x-sdp", FileExtensions._sdp, ".sdp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.sounder, "sounder", FileExtensions._sdr, ".sdr", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.sea, "sea", FileExtensions._sea, ".sea", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_sea, "x-sea", FileExtensions._sea, ".sea", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.set, "set", FileExtensions._set, ".set", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.sgml, "sgml", FileExtensions._sgm, ".sgm", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_sgml, "x-sgml", FileExtensions._sgm, ".sgm", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.sgml, "sgml", FileExtensions._sgml, ".sgml", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_sgml, "x-sgml", FileExtensions._sgml, ".sgml", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_bsh, "x-bsh", FileExtensions._sh, ".sh", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_sh, "x-sh", FileExtensions._sh, ".sh", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_shar, "x-shar", FileExtensions._sh, ".sh", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_sh, "x-script.sh", FileExtensions._sh, ".sh", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_bsh, "x-bsh", FileExtensions._shar, ".shar", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_shar, "x-shar", FileExtensions._shar, ".shar", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.html, "html", FileExtensions._shtml, ".shtml", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_server_parsed_html, "x-server-parsed-html", FileExtensions._shtml, ".shtml", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_psid, "x-psid", FileExtensions._sid, ".sid", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_sit, "x-sit", FileExtensions._sit, ".sit", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_stuffit, "x-stuffit", FileExtensions._sit, ".sit", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_koan, "x-koan", FileExtensions._skd, ".skd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_koan, "x-koan", FileExtensions._skm, ".skm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_koan, "x-koan", FileExtensions._skp, ".skp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_koan, "x-koan", FileExtensions._skt, ".skt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_seelogo, "x-seelogo", FileExtensions._sl, ".sl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.smil, "smil", FileExtensions._smi, ".smi", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.smil, "smil", FileExtensions._smil, ".smil", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.basic, "basic", FileExtensions._snd, ".snd", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_adpcm, "x-adpcm", FileExtensions._snd, ".snd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.solids, "solids", FileExtensions._sol, ".sol", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_pkcs7_certificates, "x-pkcs7-certificates", FileExtensions._spc, ".spc", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_speech, "x-speech", FileExtensions._spc, ".spc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.futuresplash, "futuresplash", FileExtensions._spl, ".spl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_sprite, "x-sprite", FileExtensions._spr, ".spr", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_sprite, "x-sprite", FileExtensions._sprite, ".sprite", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_wais_source, "x-wais-source", FileExtensions._src, ".src", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_server_parsed_html, "x-server-parsed-html", FileExtensions._ssi, ".ssi", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.streamingmedia, "streamingmedia", FileExtensions._ssm, ".ssm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_pki_certstore, "vnd.ms-pki.certstore", FileExtensions._sst, ".sst", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.step, "step", FileExtensions._step, ".step", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.sla, "sla", FileExtensions._stl, ".stl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_pki_stl, "vnd.ms-pki.stl", FileExtensions._stl, ".stl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_navistyle, "x-navistyle", FileExtensions._stl, ".stl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.step, "step", FileExtensions._stp, ".stp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_sv4cpio, "x-sv4cpio", FileExtensions._sv4cpio, ".sv4cpio", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_sv4crc, "x-sv4crc", FileExtensions._sv4crc, ".sv4crc", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vnd_dwg, "vnd.dwg", FileExtensions._svf, ".svf", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_dwg, "x-dwg", FileExtensions._svf, ".svf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_world, "x-world", FileExtensions._svr, ".svr", false);
            _retval.Add(MIMEContentTypes.x_world, "x-world", MIMEContentSubTypes.x_svr, "x-svr", FileExtensions._svr, ".svr", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_shockwave_flash, "x-shockwave-flash", FileExtensions._swf, ".swf", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_troff, "x-troff", FileExtensions._t, ".t", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_speech, "x-speech", FileExtensions._talk, ".talk", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_tar, "x-tar", FileExtensions._tar, ".tar", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.toolbook, "toolbook", FileExtensions._tbk, ".tbk", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_tbook, "x-tbook", FileExtensions._tbk, ".tbk", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_tcl, "x-tcl", FileExtensions._tcl, ".tcl", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_tcl, "x-script.tcl", FileExtensions._tcl, ".tcl", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_tcsh, "x-script.tcsh", FileExtensions._tcsh, ".tcsh", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_tex, "x-tex", FileExtensions._tex, ".tex", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_texinfo, "x-texinfo", FileExtensions._texi, ".texi", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_texinfo, "x-texinfo", FileExtensions._texinfo, ".texinfo", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.plain, "plain", FileExtensions._text, ".text", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._text, ".text", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.gnutar, "gnutar", FileExtensions._tgz, ".tgz", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_compressed, "x-compressed", FileExtensions._tgz, ".tgz", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.tiff, "tiff", FileExtensions._tif, ".tif", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_tiff, "x-tiff", FileExtensions._tif, ".tif", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.tiff, "tiff", FileExtensions._tiff, ".tiff", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_tiff, "x-tiff", FileExtensions._tiff, ".tiff", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_troff, "x-troff", FileExtensions._tr, ".tr", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.tsp_audio, "tsp-audio", FileExtensions._tsi, ".tsi", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.dsptype, "dsptype", FileExtensions._tsp, ".tsp", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.tsplayer, "tsplayer", FileExtensions._tsp, ".tsp", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.tab_separated_values, "tab-separated-values", FileExtensions._tsv, ".tsv", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.florian, "florian", FileExtensions._turbot, ".turbot", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.plain, "plain", FileExtensions._txt, ".txt", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_uil, "x-uil", FileExtensions._uil, ".uil", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.uri_list, "uri-list", FileExtensions._uni, ".uni", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.uri_list, "uri-list", FileExtensions._unis, ".unis", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.i_deas, "i-deas", FileExtensions._unv, ".unv", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.uri_list, "uri-list", FileExtensions._uri, ".uri", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.uri_list, "uri-list", FileExtensions._uris, ".uris", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_ustar, "x-ustar", FileExtensions._ustar, ".ustar", false);
            _retval.Add(MIMEContentTypes.multipart, "multipart", MIMEContentSubTypes.x_ustar, "x-ustar", FileExtensions._ustar, ".ustar", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._uu, ".uu", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_uuencode, "x-uuencode", FileExtensions._uu, ".uu", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_uuencode, "x-uuencode", FileExtensions._uue, ".uue", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_cdlink, "x-cdlink", FileExtensions._vcd, ".vcd", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_vcalendar, "x-vcalendar", FileExtensions._vcs, ".vcs", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vda, "vda", FileExtensions._vda, ".vda", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.vdo, "vdo", FileExtensions._vdo, ".vdo", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.groupwise, "groupwise", FileExtensions._vew, ".vew", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.vivo, "vivo", FileExtensions._viv, ".viv", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.vnd_vivo, "vnd.vivo", FileExtensions._viv, ".viv", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.vivo, "vivo", FileExtensions._vivo, ".vivo", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.vnd_vivo, "vnd.vivo", FileExtensions._vivo, ".vivo", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vocaltec_media_desc, "vocaltec-media-desc", FileExtensions._vmd, ".vmd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vocaltec_media_file, "vocaltec-media-file", FileExtensions._vmf, ".vmf", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.voc, "voc", FileExtensions._voc, ".voc", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_voc, "x-voc", FileExtensions._voc, ".voc", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.vosaic, "vosaic", FileExtensions._vos, ".vos", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.voxware, "voxware", FileExtensions._vox, ".vox", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_twinvq_plugin, "x-twinvq-plugin", FileExtensions._vqe, ".vqe", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_twinvq, "x-twinvq", FileExtensions._vqf, ".vqf", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_twinvq_plugin, "x-twinvq-plugin", FileExtensions._vql, ".vql", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_vrml, "x-vrml", FileExtensions._vrml, ".vrml", false);
            _retval.Add(MIMEContentTypes.model, "model", MIMEContentSubTypes.vrml, "vrml", FileExtensions._vrml, ".vrml", false);
            _retval.Add(MIMEContentTypes.x_world, "x-world", MIMEContentSubTypes.x_vrml, "x-vrml", FileExtensions._vrml, ".vrml", false);
            _retval.Add(MIMEContentTypes.x_world, "x-world", MIMEContentSubTypes.x_vrt, "x-vrt", FileExtensions._vrt, ".vrt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_visio, "x-visio", FileExtensions._vsd, ".vsd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_visio, "x-visio", FileExtensions._vst, ".vst", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_visio, "x-visio", FileExtensions._vsw, ".vsw", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.wordperfect6_0, "wordperfect6.0", FileExtensions._w60, ".w60", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.wordperfect6_1, "wordperfect6.1", FileExtensions._w61, ".w61", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.msword, "msword", FileExtensions._w6w, ".w6w", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.wav, "wav", FileExtensions._wav, ".wav", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.x_wav, "x-wav", FileExtensions._wav, ".wav", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_qpro, "x-qpro", FileExtensions._wb1, ".wb1", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vnd_wap_wbmp, "vnd.wap.wbmp", FileExtensions._wbmp, ".wbmp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_xara, "vnd.xara", FileExtensions._web, ".web", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.msword, "msword", FileExtensions._wiz, ".wiz", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_123, "x-123", FileExtensions._wk1, ".wk1", false);
            _retval.Add(MIMEContentTypes.windows, "windows", MIMEContentSubTypes.metafile, "metafile", FileExtensions._wmf, ".wmf", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.vnd_wap_wml, "vnd.wap.wml", FileExtensions._wml, ".wml", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_wap_wmlc, "vnd.wap.wmlc", FileExtensions._wmlc, ".wmlc", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.vnd_wap_wmlscript, "vnd.wap.wmlscript", FileExtensions._wmls, ".wmls", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_wap_wmlscriptc, "vnd.wap.wmlscriptc", FileExtensions._wmlsc, ".wmlsc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.msword, "msword", FileExtensions._word, ".word", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.wordperfect, "wordperfect", FileExtensions._wp, ".wp", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.wordperfect, "wordperfect", FileExtensions._wp5, ".wp5", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.wordperfect6_0, "wordperfect6.0", FileExtensions._wp5, ".wp5", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.wordperfect, "wordperfect", FileExtensions._wp6, ".wp6", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.wordperfect, "wordperfect", FileExtensions._wpd, ".wpd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_wpwin, "x-wpwin", FileExtensions._wpd, ".wpd", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_lotus, "x-lotus", FileExtensions._wq1, ".wq1", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.mswrite, "mswrite", FileExtensions._wri, ".wri", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_wri, "x-wri", FileExtensions._wri, ".wri", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_world, "x-world", FileExtensions._wrl, ".wrl", false);
            _retval.Add(MIMEContentTypes.model, "model", MIMEContentSubTypes.vrml, "vrml", FileExtensions._wrl, ".wrl", false);
            _retval.Add(MIMEContentTypes.x_world, "x-world", MIMEContentSubTypes.x_vrml, "x-vrml", FileExtensions._wrl, ".wrl", false);
            _retval.Add(MIMEContentTypes.model, "model", MIMEContentSubTypes.vrml, "vrml", FileExtensions._wrz, ".wrz", false);
            _retval.Add(MIMEContentTypes.x_world, "x-world", MIMEContentSubTypes.x_vrml, "x-vrml", FileExtensions._wrz, ".wrz", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.scriplet, "scriplet", FileExtensions._wsc, ".wsc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_wais_source, "x-wais-source", FileExtensions._wsrc, ".wsrc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_wintalk, "x-wintalk", FileExtensions._wtk, ".wtk", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_xbitmap, "x-xbitmap", FileExtensions._xbm, ".xbm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_xbm, "x-xbm", FileExtensions._xbm, ".xbm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.xbm, "xbm", FileExtensions._xbm, ".xbm", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_amt_demorun, "x-amt-demorun", FileExtensions._xdr, ".xdr", false);
            _retval.Add(MIMEContentTypes.xgl, "xgl", MIMEContentSubTypes.drawing, "drawing", FileExtensions._xgz, ".xgz", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.vnd_xiff, "vnd.xiff", FileExtensions._xif, ".xif", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xl, ".xl", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xla, ".xla", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xla, ".xla", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_msexcel, "x-msexcel", FileExtensions._xla, ".xla", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xlb, ".xlb", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_excel, "vnd.ms-excel", FileExtensions._xlb, ".xlb", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xlb, ".xlb", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xlc, ".xlc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_excel, "vnd.ms-excel", FileExtensions._xlc, ".xlc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xlc, ".xlc", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xld, ".xld", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xld, ".xld", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xlk, ".xlk", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xlk, ".xlk", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xll, ".xll", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_excel, "vnd.ms-excel", FileExtensions._xll, ".xll", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xll, ".xll", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xlm, ".xlm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_excel, "vnd.ms-excel", FileExtensions._xlm, ".xlm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xlm, ".xlm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xls, ".xls", true);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_excel, "vnd.ms-excel", FileExtensions._xls, ".xls", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xls, ".xls", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_msexcel, "x-msexcel", FileExtensions._xls, ".xls", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xlt, ".xlt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xlt, ".xlt", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xlv, ".xlv", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xlv, ".xlv", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.excel, "excel", FileExtensions._xlw, ".xlw", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.vnd_ms_excel, "vnd.ms-excel", FileExtensions._xlw, ".xlw", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_excel, "x-excel", FileExtensions._xlw, ".xlw", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_msexcel, "x-msexcel", FileExtensions._xlw, ".xlw", false);
            _retval.Add(MIMEContentTypes.audio, "audio", MIMEContentSubTypes.xm, "xm", FileExtensions._xm, ".xm", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.xml, "xml", FileExtensions._xml, ".xml", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.xml, "xml", FileExtensions._xml, ".xml", false);
            _retval.Add(MIMEContentTypes.xgl, "xgl", MIMEContentSubTypes.movie, "movie", FileExtensions._xmz, ".xmz", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_vnd_ls_xpix, "x-vnd.ls-xpix", FileExtensions._xpix, ".xpix", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_xpixmap, "x-xpixmap", FileExtensions._xpm, ".xpm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.xpm, "xpm", FileExtensions._xpm, ".xpm", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.png, "png", FileExtensions._x_png, ".x-png", false);
            _retval.Add(MIMEContentTypes.video, "video", MIMEContentSubTypes.x_amt_showrun, "x-amt-showrun", FileExtensions._xsr, ".xsr", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_xwd, "x-xwd", FileExtensions._xwd, ".xwd", false);
            _retval.Add(MIMEContentTypes.image, "image", MIMEContentSubTypes.x_xwindowdump, "x-xwindowdump", FileExtensions._xwd, ".xwd", false);
            _retval.Add(MIMEContentTypes.chemical, "chemical", MIMEContentSubTypes.x_pdb, "x-pdb", FileExtensions._xyz, ".xyz", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_compress, "x-compress", FileExtensions._z, ".z", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_compressed, "x-compressed", FileExtensions._z, ".z", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_compressed, "x-compressed", FileExtensions._zip, ".zip", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.x_zip_compressed, "x-zip-compressed", FileExtensions._zip, ".zip", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.zip, "zip", FileExtensions._zip, ".zip", false);
            _retval.Add(MIMEContentTypes.multipart, "multipart", MIMEContentSubTypes.x_zip, "x-zip", FileExtensions._zip, ".zip", false);
            _retval.Add(MIMEContentTypes.application, "application", MIMEContentSubTypes.octet_stream, "octet-stream", FileExtensions._zoo, ".zoo", false);
            _retval.Add(MIMEContentTypes.text, "text", MIMEContentSubTypes.x_script_zsh, "x-script.zsh", FileExtensions._zsh, ".zsh", false);

			return _retval;
		}

		#endregion GetDefault()

		#region PrediacteByFullContentType

        /// <summary>
        ///  predicate class by FullContentType
        /// </summary>
        private class PrediacteByFullContentType
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PrediacteByFullContentType"/> class.
            /// </summary>
            /// <param name="comparedToFullContentType">Type of the compared to full content.</param>
            public PrediacteByFullContentType(string comparedToFullContentType)
            {
                this.ComparedToFullContentType = comparedToFullContentType;
            }

            /// <summary>
            /// Gets or sets the type of the compared to full content.
            /// </summary>
            /// <value>
            /// The type of the compared to full content.
            /// </value>
            private string ComparedToFullContentType { get; set; }

            /// <summary>
            /// Predicates the specified input.
            /// </summary>
            /// <param name="input">The input.</param>
            /// <returns>true if meets criteria, otherwise false</returns>
            public bool Predicate(MIMEContentTypeToFileExtensionMappingItem input)
            {
                return input!= null && input.FullContentType == ComparedToFullContentType;
            }
        }

        /// <summary>
        /// Existses the type of the by full content.
        /// </summary>
        /// <param name="fullContentType">Full type of the content.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public bool ExistsByFullContentType(string fullContentType)
        {
            return this.Count(t => t.FullContentType == fullContentType) > 0;
        }


        /// <summary>
        /// Gets the type of the by full content.
        /// </summary>
        /// <param name="fullContentType">Full type of the content.</param>
        /// <returns><see cref="MIMEContentTypeToFileExtensionMappingItem"/></returns>
        public MIMEContentTypeToFileExtensionMappingItem GetByFullContentType(string fullContentType)
        {
            return this.Single(t => t.FullContentType == fullContentType);
        }

        /// <summary>
        /// Gets the type of the list by full content.
        /// </summary>
        /// <param name="fullContentType">Full type of the content.</param>
        /// <returns><see cref="List&lt;MIMEContentTypeToFileExtensionMappingItem&gt;"/></returns>
        protected List<MIMEContentTypeToFileExtensionMappingItem> GetListByFullContentType(string fullContentType)
        {
            List<MIMEContentTypeToFileExtensionMappingItem> _retval = new List<MIMEContentTypeToFileExtensionMappingItem>();
            _retval.AddRange(this.Where(t => t.FullContentType == fullContentType));
            return _retval;
        }

		
        /// <summary>
        /// Gets the type of the collection by full content.
        /// </summary>
        /// <param name="fullContentType">Full type of the content.</param>
        /// <returns><see cref="MIMEContentTypeToFileExtensionMappingCollection"/></returns>
        public MIMEContentTypeToFileExtensionMappingCollection GetCollectionByFullContentType(string fullContentType)
        {
            MIMEContentTypeToFileExtensionMappingCollection  _retval = new MIMEContentTypeToFileExtensionMappingCollection();
            _retval.AddRange(this.Where(t => t.FullContentType == fullContentType));
            return _retval;
        }

        #endregion PrediacteByFullContentType

    }
}