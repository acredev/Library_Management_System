# 📚 Library Management System
>경민대학교 융합소프트웨어과 2학년 A반 2학기<br>C#.NET 활용 기말고사 대체 프로젝트

## ⚙️ 개발환경
* IDE<br>
<a href="https://github.com/acredev/Library_Management_System"><img src="https://img.shields.io/badge/Visual Studio 2019-5C2D91?style=for-the-badge&logo=VisualStudio&logoColor=white"/></a>
<a href="https://github.com/acredev/Library_Management_System"><img src="https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=MySQL&logoColor=white"/></a>
* Language<br>
<a href="https://github.com/acredev/Library_Management_System"><img src="https://img.shields.io/badge/C Sharp-239120?style=for-the-badge&logo=CSharp&logoColor=white"/></a>

## 👨🏻‍💻 개발규모
* 1인 개발

## 🖥️ 지원 플랫폼
* Computer Program<br>
<a href="https://github.com/acredev/Library_Management_System"><img src="https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=Windows&logoColor=white"/></a>

## 🕒 개발기간
* 개발 : 2022. 09. 15 ~ 2022. 11. 30
* 테스트 : 2022. 11. 30 ~ 2022. 12. 01
* 릴리즈 : (예정)

## 🖧 ERD 설계도
![Untitled](https://user-images.githubusercontent.com/3482382/204815390-200e6e40-4756-4ebc-b06d-2aac1aed9a8d.png)<br>

## 📑 WinForm 구성
* 총 13개의 `WinForm`으로 구성되어 있으며, 나눔고딕 `font`를 이용해 사용자의 가독성을 높였습니다.
* 메인 `Form` / 개인 사용자 `Form` / 도서관 관리자 `Form` 별 `BackColor`을 구분해 각 `Form`마다 구별성을 두었습니다. 과하지 않은 `Color` 값으로 사용자의 편의성을 도모했습니다.
  * 메인 `Form` : `Lavender`
  * 개인 사용자 `Form` : `199, 185, 255` (`R`,`G`,`B`)
  * 도서관 관리자 `Form` : `185, 206, 172` (`R`,`G`,`B`)
  * 이메일 문의접수 `Form` : `Beige`
* `WinForm`별 작동 방식은 아래와 같습니다.
  * `a. Main.cs`<br><br>
  ![a  Main](https://user-images.githubusercontent.com/3482382/204792480-dd0d7aba-241f-40b3-b6e2-e9b3d817b0c6.png)<br>
    * 프로그램의 `메인 화면`입니다. `개인 사용자` 로그인 화면과 `도서관 관리자` 로그인 화면을 구분했습니다.

  * `b. Login_master.cs`<br><br>
  ![b  Login_Master](https://user-images.githubusercontent.com/3482382/204792594-8f1fc6fc-e2c9-4400-8573-4bc23fd98b0d.png)<br>
    * `도서관 관리자` 로그인 화면입니다.

  * `c. Master_Find_IDPW.cs`<br><br>
  ![c  Master_Find_IDPW](https://user-images.githubusercontent.com/3482382/204792604-9141797a-5548-443d-83a9-f22c3f1afc22.png)<br>
    * 관리자 계정은 `DB` 거의 모든 정보에 접근할 수 있기 때문에, 보안상의 이유로 해당 기능은 막아두었습니다. 최상위 관리자가 사용하는 `master` 계정이 존재하므로, 관리자 `ID` 또는 `PW`를 분실했을 경우 `master` 계정으로 로그인 후 조치하면 됩니다.

  * `d. Login_normal.cs`<br><br>
  ![d  Login_Normal](https://user-images.githubusercontent.com/3482382/204792612-c4d04aad-cd71-4250-9955-eefab8f28571.png)<br>
    * `개인 사용자` (도서관 이용자) 로그인 화면입니다. MySQL DB (`library_project.member`)에 등록된 정보와 일치하는지 검증하고, 일치하면 로그인이 완료됩니다.

  * `e. Normal_Find_ID.cs`<br><br>
  ![e  Normal_Find_ID](https://user-images.githubusercontent.com/3482382/204792621-39184c82-3a30-40c0-ac59-21b0c9684869.png)<br>
    * `개인 사용자` (도서관 이용자) 아이디 찾기 화면입니다. MySQL DB (`library_project.member`)에 저장된 본인 연락처로 본인인증 후 `ID`를 찾을 수 있습니다.

  * `f. Normal_Find_PW.cs`<br><br>
  ![f  Normal_Find_PW](https://user-images.githubusercontent.com/3482382/204792624-98992356-886d-476b-a0ee-099aeb86e93b.png)<br>
    * `개인 사용자` (도서관 이용자) 비밀번호 찾기 화면입니다. MySQL DB (`library_project.member`)에 저장된 본인 아이디를 조회하고, 해당 아이디값에 저장된 연락처로 본인인증을 합니다.
    * 모든 절차가 완료되는 즉시 `난수열`을 발생시키고, MySQL DB (`library_project.member`)에 저장된 본인 아이디를 다시 조회합니다.
    * 해당 아이디값에 저장된 비밀번호 값을 발생한 `난수열`값으로 변경합니다.
    * 사용자에게 변경된 `난수열`값을 회원정보에 등록되어 있는 `개인 연락수단`과 `MessageBox`로 고지합니다.

  * `g. NewMember_PersonalInformation.cs`<br><br>
  ![g  NewMember_PersonalInformation](https://user-images.githubusercontent.com/3482382/204792632-728e162a-e404-4bdc-bdb6-ed49b0255c98.png)<br>
    * 개인정보 보호법 시행령에 의거, 회원가입 시 개인 사용자 (도서관 이용자)의 개인정보 활용 동의를 받는 화면입니다. 모든 이용약관에 동의했다면, `h. NewMember_Normal.cs`로 연결됩니다.

  * `h. NewMember_Normal.cs`<br><br>
  ![h  NewMember_Normal](https://user-images.githubusercontent.com/3482382/204792639-82894d11-fe01-4068-b4f7-0ae7192b4798.png)<br>
    * 아이디값이 `DB`에 중복되는 정보인지 확인합니다.
    * 연락처, 이메일 본인인증을 진행합니다. 모든 본인인증이 완료되었는지 여부를 판단합니다.
    * 회원가입 즉시 `yyMMddhhmmss` 형태의 `회원번호`를 생성하고, 현재 날짜와 사용자가 입력한 값과 함께 MySQL DB (`library_project.member`)에 등록합니다.

  * `i. Master.cs (TAB 1)`<br><br>
  ![i  Master_tab1](https://user-images.githubusercontent.com/3482382/204792679-7479f14b-bd8c-41fa-ac25-dbdad036d9ed.png)<br>
    * 회원의 `대출/반납`을 처리할 수 있습니다. 자동으로 생성되는 `회원번호`와 도서 `관리번호`가 이때 사용됩니다.
    * 회원이 대출한 도서가 아닐 경우, `반납` 처리가 되지 않습니다.
    * 회원 상태가 `정상`이 아닐 경우, `대출` 처리가 되지 않습니다.
    * 이미 타 회원이 대출해간 도서일 경우, 타 회원에게 `대출` 처리가 되지 않습니다.
    * 1회원당 최대 10권까지 `대출`이 가능하고, 넘을 경우 `대출` 처리가 되지 않습니다.<br><br>
  * `i. Master.cs (TAB 2)`<br><br>
  ![i  Master_tab2](https://user-images.githubusercontent.com/3482382/204792684-167aae77-acee-41ec-aef4-999fa95551ae.png)<br>
    * 도서를 관리할 수 있습니다. `정보 수정` / `신규 등록` / `도서 삭제`가 가능합니다.
    * `범주`에 맞게 `검색` 할 수 있습니다.
    * 신규 도서 등록 즉시, `ssmmhhddMMyy` 형태의 도서 관리번호를 생성하고, 관리자가 입력한 값과 함께 MySQL DB (`library_project.master`)에 등록합니다.<br><br>
  * `i. Master.cs (TAB 3)`<br><br>
  ![i  Master_tab3](https://user-images.githubusercontent.com/3482382/204792687-6e3d0b4d-49b2-4dbf-8c8c-6812ca7a352d.png)<br>
    * 회원을 관리할 수 있습니다. `회원정보 수정` / `회원 강제탈퇴`가 가능합니다.
    * `범주`에 맞게 `검색` 할 수 있습니다.
    * `회원번호`와 `아이디`는 변경할 수 없습니다.
    * 회원이 대출한 도서가 있을 경우, `강제 탈퇴` 처리가 불가능합니다.<br><br>
  * `i. Master.cs (TAB 4)`<br><br>
  ![i  Master_tab4](https://user-images.githubusercontent.com/3482382/204792693-90118725-75e1-4b6c-ab6c-543e285af62e.png)<br>
    * `공지사항` 게시판과 `자유 게시판` 글을 동시에 관리할 수 있습니다. `열람 모드` / `수정 모드` / `삭제 모드`에 맞게 관리할 수 있습니다. ( + `자유 게시판` 글은 `신규작성` 불가)
    * `범주`에 맞게 `검색` 할 수 있습니다.<br><br>
  * `i. Master.cs (TAB 5)`<br><br>
  ![i  Master_tab5](https://user-images.githubusercontent.com/3482382/204792698-0f7b97ea-caa2-4b60-ab42-b5a0940b6375.png)<br>
    * 사용자가 등록한 `문의사항/건의사항` 게시글을 관리할 수 있습니다. `열람 모드` / `삭제/답변 모드`에 맞게 관리할 수 있습니다.
    * `범주`에 맞게 `검색` 할 수 있습니다.
    * `문의`에 대한 `답변`을 할 수 있으며, `답변 내용`을 MySQL DB (`library_project.member`)에 등록된 `회원 EMail`로 전송할지 여부를 선택할 수 있습니다.
    * `문의 답변등록 알림 이메일 발송` 선택 시에는, `답변 작성` 알림과 함께 `답변 내용`이 `회원 EMail`로 전송됩니다.<br><br>
  * `i. Master.cs (TAB 6)`<br><br>
  ![i  Master_tab6](https://user-images.githubusercontent.com/3482382/204792699-d342a4b9-e1f4-44ff-8c94-588e2d229bd3.png)<br>
    * MySQL SCHEMAS (`library_project`)를 `Backup`할 수 있습니다. `C:\1234library` 폴더를 생성하고, `1234library_data_backup.sql`파일로 저장됩니다.
    * MySQL SCHEMAS (`library_project`)를 `Restore`할 수 있습니다. `C:\1234library` 폴더에 위치한 `1234library_data_backup.sql`파일로 `Restore`하며, 완료 즉시 `Application.Restart` 됩니다.<br><br>

  * `j. Normal.cs`<br><br>
  ![j  Normal](https://user-images.githubusercontent.com/3482382/204792712-6b193c22-f561-4787-9c15-37cf94a92bef.png)<br>
    * `개인 사용자` (도서관 이용자)가 이용할 화면입니다. `도서관 관리자` 화면보다 손쉽게 사용할 수 있도록 설계했습니다.
    * `Form Load` 즉시 MySQL DB (`library_project.member`)에 등록된 간략한 회원 정보가 `label`에 로드됩니다.
    * `Form Load` 즉시 MySQL DB (`library_project.board_notice`)가 로드되며, `datagridview`에 출력됩니다.
    * 우측 상단 두개의 `PictureBox` 중, `상담원 모양`을 클릭하면 `r. SupportMail.cs`가 로드됩니다.
    * 우측 상단 두개의 `PictureBox` 중, `나가는 문 모양`을 클릭하면 `Logout`됨과 동시에 `Application.Restart` 됩니다.<br><br>

  * `k. Normal_loanBook.cs`<br><br>
  ![k  Normal_loanBook](https://user-images.githubusercontent.com/3482382/204792729-d7135f3c-93c2-46a0-9ea0-c71667e7d09c.png)<br>
    * `Form Load` 즉시 `Normal.cs`에서 확인할 수 있는 사용자의 회원번호로 MySQL DB (`library_project.member`)를 조회해서 변수에 저장합니다.
    * `Form Load` 즉시 MySQL DB (`library_project.book`)의 일부 정보만 로드합니다. 특히, `대출/반납` 화면에서는 필수 정보만 보여주는 것이 사용성에 도움이 되기 때문입니다.
    * `범주`에 맞게 `검색` 할 수 있습니다.
    * 조회한 회원정보의 `회원상태`가 정상일 경우 `대출` 처리가 가능하고, 그 이외일 경우 불가합니다.
    * 조회한 회원정보의 `대출권수`가 0~9권 이내일 경우 `대출` 처리가 가능하고, 그 이외일 경우 불가합니다.
    * 조회한 도서정보의 `대출한_회원번호`의 값이 로그인한 회원번호와 같을 경우 `반납` 처리가 가능하고, 그 이외일 경우 불가합니다.<br><br>

  * `l. Normal_SearchBook.cs`<br><br>
  ![l  Normal_SearchBook](https://user-images.githubusercontent.com/3482382/204792740-8d30cd6e-475c-4119-95ab-d2a9c4cea7e1.png)<br>
    * `Form Load` 즉시 MySQL DB (`library_project.book`)의 `관리번호`, `대출한_회원번호` `columns`를 제외한 정보만 로드합니다.
    * `범주`에 맞게 `검색` 할 수 있습니다.<br><br>

  * `m. Normal_board.cs`<br><br>
  ![m  Normal_Board](https://user-images.githubusercontent.com/3482382/204792747-ff45efe8-d9c7-4782-981d-a35c42d299d0.png)<br>
    * `Form Load` 즉시 MySQL DB (`library_project.board_notice`)의 전체 정보, `library_project.board_free`의 `회원번호`를 제외한 정보만 로드합니다.
    * `공지사항`과 `자유 게시판`을 열람하고, `자유 게시판`에 게시글을 `신규 작성`할 수 있습니다.<br><br>

  * `n. Normal_BeforeMypage.cs`<br><br>
  ![n  Normal_BeforeMypage](https://user-images.githubusercontent.com/3482382/204792754-c4e8b87f-62ca-4337-a913-563880e568f0.png)<br>
    * `Normal_Mypage.cs` 진입 전, 보안을 위해 로그인한 사용자의 `PW`를 한번 더 확인합니다.<br><br>

  * `o. Normal_Mypage.cs`<br><br>
  ![o  Normal_Mypage](https://user-images.githubusercontent.com/3482382/204792793-dcbd85ea-0148-4bf9-ad48-5a5ee8351c15.png)<br>
    * `Form Load` 즉시 MySQL DB (`library_project.member`)의 전체 정보가 로드됩니다.
    * 사용자는 `이름`, `회원번호`, `아이디`, `회원상태`, `대출권수`, `가입일`을 수정할 수 없습니다.
    * `회원정보 수정`시에는 필수로 `연락처` 본인인증과 `이메일` 본인인증 절차를 거쳐야만 가능합니다.<br><br>

  * `p. Normal_Qna.cs`<br><br>
  ![p  Normal_Qna](https://user-images.githubusercontent.com/3482382/204792803-498e0845-ea48-4081-8376-a72477553915.png)<br>
    * `Form Load` 즉시 MySQL DB (`library_project.notice_qna`)의 `회원번호`, `작성자`, `회원EMail`, `답변` `columns`를 제외한 정보만 로드합니다.
    * `문의사항 / 건의사항` 게시판에 게시글을 `신규 작성`할 수 있습니다.<br><br>

  * `q. SupportMail_Before.cs`<br><br>
  ![q  SupportMail_Before](https://user-images.githubusercontent.com/3482382/204792819-57c9d3d0-21f5-4d95-baef-92642d0e32ef.png)<br>
    * 비로그인 상태에서 이용하고자 할 경우에 출력되는 화면입니다. 스팸 방지를 위해, 비로그인 상태에서는 `본인인증`을 필수로 해야 진입이 가능합니다.<br><br>

  * `r. SupportMail.cs`<br><br>
  ![r  SupportMail](https://user-images.githubusercontent.com/3482382/204792846-3f2c046a-5dde-4bcd-8890-b78f24da7d20.png)<br>
    * `Form Load` 즉시 사용자 컴퓨터의 기본 정보를 로드합니다.
    * 프로그램 문제에 대해 `EMail`로 문의접수가 가능합니다.
